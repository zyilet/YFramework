using System;
using Cysharp.Threading.Tasks;
using GameScripts.HotUpdate.Systems.Log;
using GameScripts.HotUpdate.Systems.UI;
using GameScripts.HotUpdate.UpdateAssets.UI.Panels;
using MessagePipe;
using NodeCanvas.Framework;
using NodeCanvas.StateMachines;
using ParadoxNotion.Design;
using VContainer;
using YooAsset;

namespace GameScripts.HotUpdate.UpdateAssets.FsmStates
{
    [Category("UpdateAssets")]
    public class UpdateVersion : FSMState
    {
        [Inject] private ILog _log;
        [Inject] private IPublisher<UpdateProgressChange> _progressPublisher;
        [Inject] private IPublisher<UpdateResourceFailedInfo> _updateResourceCallbackPublisher;
        [Inject] private IUI _ui;
        [Inject] private ResourcePackage _package;
        private UpdatePackageVersionOperation _updatePackageVersionOperation;

        protected override void OnEnter()
        {
            //更新之前先卸载资源
            _package.ForceUnloadAllAssets();
            
            _updatePackageVersionOperation = _package.UpdatePackageVersionAsync();
            NotifyProgress(_updatePackageVersionOperation);
        }

        protected override void OnUpdate()
        {
            switch (_updatePackageVersionOperation.Status)
            {
                case EOperationStatus.None:
                    NotifyProgress(_updatePackageVersionOperation);
                    return;
                case EOperationStatus.Failed:
                    FSM.Pause();
                    _ui.Push<UpdateResourceInfoBox>();
                    _updateResourceCallbackPublisher.Publish(new UpdateResourceFailedInfo()
                    {
                        Info = "更新版本信息失败",
                        Callback = () =>
                        {
                            _ui.Pop();
                            FSM.Resume();
                            FSM.TriggerState(name, FSM.TransitionCallMode.Normal);
                        }
                    });
                    return;
                case EOperationStatus.Succeed:
                    NotifyProgress(_updatePackageVersionOperation);
                    graphBlackboard.SetVariableValue("PackageVersion", _updatePackageVersionOperation.PackageVersion);
                    Finish();
                    return;
            }
        }

        private void NotifyProgress(UpdatePackageVersionOperation updatePackageVersionOperation)
        {
            _progressPublisher.Publish(new UpdateProgressChange()
            {
                Value = updatePackageVersionOperation.Progress,
                UpdatePhase = "检查版本"
            });
        }
    }
}
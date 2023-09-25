using System;
using Cysharp.Threading.Tasks;
using GameScripts.HotUpdate.Systems.UI;
using GameScripts.HotUpdate.UpdateAssets;
using GameScripts.HotUpdate.UpdateAssets.UI.Panels;
using MessagePipe;
using NodeCanvas.Framework;
using NodeCanvas.StateMachines;
using ParadoxNotion.Design;
using UnityEngine;
using VContainer;
using YooAsset;

namespace GameScripts.Aot.GameLogic.UpdateResource.States
{
    [Category("UpdateAssets")]
    public class UpdateManifest : FSMState
    {
        [Inject] private IUI _ui;
        [Inject] private IPublisher<UpdateProgressChange> _updateProgressChangePublisher;
        [Inject] private IPublisher<UpdateResourceFailedInfo> _updateFailedPublisher;
        [Inject] private ResourcePackage _package;
        private UpdatePackageManifestOperation _operation;

        protected override void OnEnter()
        {
            _operation = _package.UpdatePackageManifestAsync(graphBlackboard.GetVariable<string>("PackageVersion").value);
            Notify(_operation);
        }

        protected override void OnUpdate()
        {
            switch (_operation.Status)
            {
                case EOperationStatus.None:
                    Notify(_operation);
                    break;
                case EOperationStatus.Succeed:
                    Notify(_operation);
                    Finish();
                    break;
                case EOperationStatus.Failed:
                    FSM.Pause();
                    _ui.Push<UpdateResourceInfoBox>();
                    _updateFailedPublisher.Publish(new UpdateResourceFailedInfo()
                    {
                        Info = "更新版本信息失败",
                        Callback = () =>
                        {
                            _ui.Pop();
                            FSM.Resume();
                            FSM.TriggerState(name, FSM.TransitionCallMode.Normal);
                        }
                    });
                    break;
            }
        }

        private void Notify(UpdatePackageManifestOperation operation)
        {
            _updateProgressChangePublisher.Publish(new UpdateProgressChange()
            {
                Value = operation.Progress,
                UpdatePhase = "更新资源清单"
            });
        }
    }
}
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
    public class DownloadFiles : FSMState
    {
        private int _totalDownloadCount;
        private int _currentDownloadCount;
        private long _totalDownloadSizeBytes;
        private long _currentDownloadSizeBytes;

        private string _failedFileName;
        private string _error;

        [Inject] private IPublisher<UpdateProgressChange> _updateProgressPublisher;
        [Inject] private IPublisher<UpdateResourceFailedInfo> _updateFailedPublisher;
        [Inject] private IUI _ui;
        private ResourceDownloaderOperation _downloader;

        protected override void OnEnter()
        {
            _downloader = graphBlackboard.GetVariable("DownloadingOperation").value as ResourceDownloaderOperation;
            
            // 注册下载回调
            _downloader.OnDownloadErrorCallback = (fileName, error) =>
            {
                _failedFileName = fileName;
                _error = error;
            };
            _downloader.OnDownloadProgressCallback = (count, downloadCount, bytes, downloadBytes) =>
            {
                _totalDownloadCount = count;
                _currentDownloadCount = downloadCount;
                _totalDownloadSizeBytes = bytes;
                _currentDownloadSizeBytes = downloadBytes;
            };

            _downloader.BeginDownload();
            Notify(_downloader);
        }

        protected override void OnUpdate()
        {
            switch (_downloader.Status)
            {
                case EOperationStatus.None:
                    Notify(_downloader);
                    break;
                case EOperationStatus.Succeed:
                    graphBlackboard.SetVariableValue("IsDownloadSucceed", true);
                    Notify(_downloader);
                    Finish();
                    break;
                case EOperationStatus.Failed:
                    graphBlackboard.SetVariableValue("IsDownloadSucceed", false);
                    FSM.Pause();
                    Finish();
                    _ui.Push<UpdateResourceInfoBox>();
                    _updateFailedPublisher.Publish(new UpdateResourceFailedInfo()
                    {
                        Info = "下载资源文件失败",
                        Callback = () =>
                        {
                            _ui.Pop();
                            FSM.Resume();
                        }
                    });
                    break;
            }
        }

        private void Notify(ResourceDownloaderOperation downloader)
        {
            _updateProgressPublisher.Publish(new UpdateProgressChange()
            {
                Value = downloader.Progress,
                UpdatePhase = "下载更新文件"
            });
            
            Debug.Log("下载进度："+downloader.Progress);
        }
    }
}
using System;
using Cysharp.Threading.Tasks;
using NodeCanvas.StateMachines;
using ParadoxNotion.Design;
using VContainer;
using YooAsset;

namespace GameScripts.Aot.GameLogic.UpdateResource.States
{
    [Category("UpdateAssets")]
    public class DownloadOver : FSMState
    {
        [Inject] private ResourcePackage _package;
        private ClearUnusedCacheFilesOperation _operation;

        protected override async void OnEnter()
        {
            await UniTask.Delay(TimeSpan.FromSeconds(1d));
            _operation = _package.ClearUnusedCacheFilesAsync();
        }

        protected override void OnUpdate()
        {
            if (_operation?.Status == EOperationStatus.Succeed)
                Finish();
        }
    }
}
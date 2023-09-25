using MessagePipe;
using NodeCanvas.Framework;
using NodeCanvas.StateMachines;
using ParadoxNotion.Design;
using VContainer;
using YooAsset;

namespace GameScripts.Aot.GameLogic.UpdateResource.States
{
    [Category("UpdateAssets")]
    public class CreateDownloader : FSMState
    {
        protected override void OnEnter()
        {
            //检查是否需要更新代码
            foreach (var assetInfo in YooAssets.GetAssetInfos("Dlls"))
            {
                if (YooAssets.IsNeedDownloadFromRemote(assetInfo))
                {
                    graphBlackboard.SetVariableValue("HaveUpdatedDlls", true);
                }
            }

            var downloader = YooAssets.CreateResourceDownloader(10, 3);

            graphBlackboard.SetVariableValue("TotalDownloadCount", downloader.TotalDownloadCount);
            graphBlackboard.SetVariableValue("DownloadingOperation", downloader);
            Finish();
        }
    }
}
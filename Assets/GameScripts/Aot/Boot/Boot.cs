using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using UnityEngine;
using YooAsset;

namespace GameScripts.Aot.Boot
{
    public class Boot : MonoBehaviour
    {
        [SerializeField] private EPlayMode _playMode;
        [SerializeField] private string _defaultServerIP;
        [SerializeField] private string _fallbackServerIP;
        [SerializeField] private string _entryTag;
        [SerializeField] private string _mateDataDllsTag;
        [SerializeField] private string _hotUpdateDllsTag;

        private async void Start()
        {
            //检查资源运行模式
            // 当运行平台不是编辑器且选择了资源模式为编辑器模拟模式，将模式更改为联机模式
#if !UNITY_EDITOR
        if (_playMode == EPlayMode.EditorSimulateMode)
            _playMode = EPlayMode.HostPlayMode;
#endif
            //初始化YooAssets
            await InitYoo();
            //初始化HybridClr（补充元数据，加载热更Dll）
            await InitHybridClr();
            //加载入口逻辑
            var entryAssetInfo = YooAssets.GetAssetInfos(_entryTag).FirstOrDefault();
            YooAssets.LoadAssetSync(entryAssetInfo).InstantiateAsync();
        }

        /// <summary>
        /// 初始化YooAssets
        /// </summary>
        private async UniTask InitYoo()
        {
            var yooInitParam = new YooAssetInitParam()
            {
                PlayMode = _playMode,
                DefaultServerIP = _defaultServerIP,
                FallbackServerIP = _fallbackServerIP,
            };
            var yooInitializer = new YooAssetsInitializer(yooInitParam);
            await yooInitializer.Init();
        }

        /// <summary>
        /// 初始化HybridClr
        /// </summary>
        private async UniTask InitHybridClr()
        {
            var mateDataDlls = await LoadDllsAsync(YooAssets.GetAssetInfos(_mateDataDllsTag).ToList());
            var hotUpdateDlls = await LoadDllsAsync(YooAssets.GetAssetInfos(_hotUpdateDllsTag).ToList());
            var hybridClrInitParam = new HybridClrInitParam()
            {
                MateDataDlls = mateDataDlls,
                HotUpdateDlls = hotUpdateDlls,
            };
            var hybridClrInitializer = new HybridClrInitializer(hybridClrInitParam);
            await hybridClrInitializer.Init();
            return;

            async UniTask<List<DllInfo>> LoadDllsAsync(List<AssetInfo> infos)
            {
                var handles = infos
                    .Select(assetInfo => YooAssets.LoadAssetAsync<TextAsset>(assetInfo.AssetPath))
                    .ToList();

                await UniTask.WhenAll(handles.Select(handle => handle.ToUniTask()));

                return handles
                    .Select(handle => new DllInfo()
                    {
                        Path = handle.GetAssetInfo().AssetPath,
                        Dll = handle.GetAssetObject<TextAsset>().bytes
                    })
                    .ToList();
            }
        }
    }
}
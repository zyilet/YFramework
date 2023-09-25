using System.IO;
using Cysharp.Threading.Tasks;
using ThirdParty.StreamingAssetsHelper;
using UnityEditor;
using UnityEngine;
using YooAsset;

namespace GameScripts.Aot.Boot
{
    public class YooAssetInitParam
    {
        public EPlayMode PlayMode { get; set; }
        public string DefaultServerIP { get; set; }
        public string FallbackServerIP { get; set; }
    }

    public class YooAssetsInitializer
    {
        private readonly YooAssetInitParam _initParam;

        public YooAssetsInitializer(YooAssetInitParam initParam)
        {
            _initParam = initParam;
        }

        public async UniTask Init()
        {
            // 初始化资源系统
            YooAssets.Initialize();
            // 创建默认的资源包
            var package = YooAssets.CreatePackage("DefaultPackage");
            // 设置该资源包为默认的资源包，可以使用YooAssets相关加载接口加载该资源包内容。
            YooAssets.SetDefaultPackage(package);
            //根据所选的运行模式初始化YooAssets
            var initTask = _initParam.PlayMode switch
            {
                EPlayMode.EditorSimulateMode => InitializeEditorSimulate(package),
                EPlayMode.OfflinePlayMode => InitializeOffline(package),
                EPlayMode.HostPlayMode => InitializeHost(package),
                _ => UniTask.CompletedTask
            };
            await initTask;
        }

        /// <summary>
        /// 编辑器模拟模式
        /// </summary>
        private async UniTask InitializeEditorSimulate(ResourcePackage package)
        {
            var initParameters = new EditorSimulateModeParameters
            {
                SimulateManifestFilePath = EditorSimulateModeHelper.SimulateBuild("DefaultPackage")
            };
            await package.InitializeAsync(initParameters);
        }

        /// <summary>
        /// 单机模式
        /// </summary>
        private async UniTask InitializeOffline(ResourcePackage package)
        {
            var initParameters = new OfflinePlayModeParameters();
            await package.InitializeAsync(initParameters);
        }

        /// <summary>
        /// 联机模式
        /// </summary>
        private async UniTask InitializeHost(ResourcePackage package)
        {
            var defaultHostServer = GetPlatformUrl(_initParam.DefaultServerIP);
            var fallbackHostServer = GetPlatformUrl(_initParam.FallbackServerIP);
            var initParameters = new HostPlayModeParameters
            {
                QueryServices = new GameQueryServices(),
                DecryptionServices = new GameDecryptionServices(),
                RemoteServices = new RemoteServices(defaultHostServer, fallbackHostServer)
            };
            var initOperation = package.InitializeAsync(initParameters);
            await initOperation;

            if (initOperation.Status == EOperationStatus.Succeed)
            {
                Debug.Log("资源包初始化成功！");
            }
            else
            {
                Debug.LogError($"资源包初始化失败：{initOperation.Error}");
            }
        }

        /// <summary>
        /// 根据当前平台生成对应的资源BaseUrl
        /// </summary>
        /// <param name="serverIP"></param>
        /// <returns></returns>
        private string GetPlatformUrl(string serverIP)
        {
#if UNITY_EDITOR
            return EditorUserBuildSettings.activeBuildTarget switch
            {
                BuildTarget.Android => $"{serverIP}/CDN/Android/Release",
                BuildTarget.iOS => $"{serverIP}/CDN/IPhone/Release",
                _ => $"{serverIP}/CDN/PC/Release"
            };
#else
        return Application.platform switch
        {
            RuntimePlatform.Android => $"{serverIP}/CDN/Android/Release",
            RuntimePlatform.IPhonePlayer => $"{serverIP}/CDN/IPhone/Release",
            _ => $"{serverIP}/CDN/PC/Release"
        };
#endif
        }

        /// <summary>
        /// 资源文件解密服务类
        /// </summary>
        private class GameDecryptionServices : IDecryptionServices
        {
            public ulong LoadFromFileOffset(DecryptFileInfo fileInfo)
            {
                return 32;
            }

            public byte[] LoadFromMemory(DecryptFileInfo fileInfo)
            {
                throw new System.NotImplementedException();
            }

            public Stream LoadFromStream(DecryptFileInfo fileInfo)
            {
                return new BundleStream(fileInfo.FilePath, FileMode.Open, FileAccess.Read, FileShare.Read);
            }

            public uint GetManagedReadBufferSize()
            {
                return 1024;
            }

            private class BundleStream : FileStream
            {
                private const byte KEY = 64;

                public BundleStream(string path, FileMode mode, FileAccess access, FileShare share) : base(path, mode, access, share)
                {
                }

                // public BundleStream(string path, FileMode mode) : base(path, mode)
                // {
                // }

                public override int Read(byte[] array, int offset, int count)
                {
                    var index = base.Read(array, offset, count);
                    for (var i = 0; i < array.Length; i++)
                    {
                        array[i] ^= KEY;
                    }

                    return index;
                }
            }
        }
        
        /// <summary>
        /// 远端资源地址查询服务类
        /// </summary>
        private class RemoteServices : IRemoteServices
        {
            private readonly string _defaultHostServer;
            private readonly string _fallbackHostServer;

            public RemoteServices(string defaultHostServer, string fallbackHostServer)
            {
                _defaultHostServer = defaultHostServer;
                _fallbackHostServer = fallbackHostServer;
            }

            string IRemoteServices.GetRemoteFallbackURL(string fileName)
            {
                return $"{_defaultHostServer}/{fileName}";
            }

            string IRemoteServices.GetRemoteMainURL(string fileName)
            {
                return $"{_fallbackHostServer}/{fileName}";
            }
        }
    }
}
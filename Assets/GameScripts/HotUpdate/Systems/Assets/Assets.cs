using Cysharp.Threading.Tasks;
using UnityEngine;
using YooAsset;

namespace GameScripts.HotUpdate.Systems.Assets
{
    public class Assets : IAssets
    {
        public async UniTask LoadSceneAsync(string location)
        {
            await YooAssets.LoadSceneAsync(location).ToUniTask();
        }

        public T LoadAsset<T>(string location) where T : Object
        {
            return YooAssets.LoadAssetSync<T>(location).GetAssetObject<T>();
        }

        public async UniTask<T> LoadAssetAsync<T>(string location) where T : Object
        {
            var handle = YooAssets.LoadAssetAsync<T>(location);
            await handle;
            return handle.GetAssetObject<T>();
        }

        public GameObject LoadAndInstantiate(string location)
        {
            return YooAssets.LoadAssetSync<GameObject>(location).InstantiateSync();
        }
    }
}
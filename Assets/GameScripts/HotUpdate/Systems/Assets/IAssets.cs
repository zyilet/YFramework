using Cysharp.Threading.Tasks;
using UnityEngine;
using YooAsset;

namespace GameScripts.HotUpdate.Systems.Assets
{
    public interface IAssets
    {
        UniTask LoadSceneAsync(string location);
        T LoadAsset<T>(string location) where T : Object;
        UniTask<T> LoadAssetAsync<T>(string location) where T : Object;
        GameObject LoadAndInstantiate(string location);
    }
}
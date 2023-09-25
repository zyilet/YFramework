using System;
using System.Reflection;
using UnityEngine;
using YooAsset;

namespace GameScripts.HotUpdate
{
    public class Entry: MonoBehaviour
    {
        private void Start()
        {
            YooAssets.GetPackage("DefaultPackage").ForceUnloadAllAssets();
            YooAssets.LoadSceneAsync("HotUpdate");
        }
    }
}
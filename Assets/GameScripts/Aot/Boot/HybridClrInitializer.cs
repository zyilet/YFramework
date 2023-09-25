using System.Collections.Generic;
using System.Reflection;
using Cysharp.Threading.Tasks;
using HybridCLR;
using UnityEngine;

namespace GameScripts.Aot.Boot
{
    public class DllInfo
    {
        public string Path { get; set; }
        public byte[] Dll { get; set; }
    }

    public class HybridClrInitParam
    {
        public List<DllInfo> MateDataDlls { get; set; }
        public List<DllInfo> HotUpdateDlls { get; set; }
    }

    public class HybridClrInitializer
    {
        private readonly HybridClrInitParam _initParam;

        public HybridClrInitializer(HybridClrInitParam initParam)
        {
            _initParam = initParam;
        }

        public UniTask Init()
        {
            foreach (var dllInfo in _initParam.MateDataDlls)
            {
                Debug.Log($"补充元数据Dll: {dllInfo.Path}");
                RuntimeApi.LoadMetadataForAOTAssembly(dllInfo.Dll, HomologousImageMode.SuperSet);
            }

            foreach (var dllInfo in _initParam.HotUpdateDlls)
            {
                Debug.Log($"加载热更Dll: {dllInfo.Path}");
                Assembly.Load(dllInfo.Dll);
            }

            return UniTask.CompletedTask;
        }
    }
}
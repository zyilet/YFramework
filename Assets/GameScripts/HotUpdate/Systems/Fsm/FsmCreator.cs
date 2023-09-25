using System;
using GameScripts.Aot.Systems.Fsm.Abstracts;
using GameScripts.HotUpdate.Systems.Assets;
using NodeCanvas.Framework;
using NodeCanvas.StateMachines;
using UnityEngine;
using VContainer;
using Object = UnityEngine.Object;

namespace GameScripts.HotUpdate.Systems.Fsm
{
    public class FsmCreator : IFsmCreator
    {
        [Inject] private IAssets _assets;
        [Inject] private IObjectResolver _objectResolver;

        public IFsmRunner Create(string graphLocation)
        {
            var graph = _assets.LoadAsset<FSM>(graphLocation);
            var fsmRunner = new FsmRunner(graph);
            fsmRunner.SetProvider(_objectResolver);
            return fsmRunner;
        }
    }


    public class FsmRunner : IFsmRunner, IDisposable
    {
        private readonly GameObject _gameObj;
        private readonly FSMOwner _fsmOwner;

        public FsmRunner(Graph graph)
        {
            _gameObj = new GameObject("FsmRunner");
            _fsmOwner = _gameObj.AddComponent<FSMOwner>();
            _fsmOwner.graph = graph;
            
            //NodeCanvas会在运行时通过asset文件反序列出node的实例，所以必须提前调用初始化方法，否则注入对象不是真实的运行时node实例
            _fsmOwner.Initialize();
        }

        public void SetProvider(IObjectResolver provider)
        {
            foreach (var node in _fsmOwner.graph.allNodes)
            {
                provider.Inject(node);
            }
        }

        public void SetOwner()
        {
        }

        public void Run()
        {
            _fsmOwner.StartBehaviour();
        }

        public void Pause()
        {
            _fsmOwner.PauseBehaviour();
        }

        public void Stop()
        {
            _fsmOwner.StopBehaviour();
        }

        public void Dispose()
        {
            Object.Destroy(_gameObj);
        }
    }
}
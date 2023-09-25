using System;
using GameScripts.HotUpdate.Game.MessageDefine;
using GameScripts.HotUpdate.Systems.Assets;
using GameScripts.HotUpdate.Systems.Log;
using GameScripts.HotUpdate.Systems.UI;
using MessagePipe;
using VContainer;
using VContainer.Unity;

namespace GameScripts.HotUpdate.Game.Scopes
{
    public class BattleRoomScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<Entry>();

            builder.Register<ILog, Log>(Lifetime.Singleton);
            builder.Register<UIUtilities>(Lifetime.Singleton);
            builder.Register<IUI, UI>(Lifetime.Singleton);
            builder.Register<IAssets, Assets>(Lifetime.Singleton);
            RegisterMessage(builder);
        }
        
        private void RegisterMessage(IContainerBuilder builder)
        {
            //注册MessagePipe，返回MessagePipeOptions
            var options = builder.RegisterMessagePipe();
            //为GlobalMessagePipe设置Provider才能使用诊断信息页面和在DI之外使用消息管道
            builder.RegisterBuildCallback(container => GlobalMessagePipe.SetProvider(container.AsServiceProvider()));

            //注册brokers
            RegisterMessageBroker<ChangeToHomeScene>();
            return;

            void RegisterMessageBroker<T>()
            {
                builder.RegisterMessageBroker<T>(options);
            }
        }
        
        public class Entry : IStartable, ITickable, IDisposable
        {
            [Inject] private IUI _ui;
            [Inject] private IAssets _assets;
            [Inject] private ISubscriber<ChangeToHomeScene> _subscriber;
            private IDisposable _disposable;

            public void Start()
            {
                // _ui.Push<GameMenuPanel>();
                _disposable = _subscriber.Subscribe(_ => _assets.LoadSceneAsync("Game"));
            }

            
            public void Tick()
            {
                
            }
            
            public void Dispose()
            {
                _disposable.Dispose();
            }
        }
    }
}
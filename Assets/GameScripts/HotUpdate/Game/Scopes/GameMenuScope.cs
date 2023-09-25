using System;
using GameScripts.Game.UI;
using GameScripts.HotUpdate.Game.MessageDefine;
using GameScripts.HotUpdate.Systems.Assets;
using GameScripts.HotUpdate.Systems.Log;
using GameScripts.HotUpdate.Systems.UI;
using GameScripts.HotUpdate.UpdateAssets;
using MessagePipe;
using VContainer;
using VContainer.Unity;

namespace GameScripts.Game.Scopes
{
    public class GameMenuScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<Entry>();

            builder.Register<ILog, Log>(Lifetime.Singleton);
            builder.Register<UIUtilities>(Lifetime.Singleton);
            builder.Register<IUI, HotUpdate.Systems.UI.UI>(Lifetime.Singleton);
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
            RegisterMessageBroker<ChangeToBattleScene>();
            return;

            void RegisterMessageBroker<T>()
            {
                builder.RegisterMessageBroker<T>(options);
            }
        }

        public class Entry : IStartable, IDisposable
        {
            [Inject] private IUI _ui;
            [Inject] private IAssets _assets;
            [Inject] private ISubscriber<ChangeToBattleScene> _subscriber;
            private IDisposable _disposable;

            public void Start()
            {
                _ui.Push<GameMenuPanel>();
                _disposable = _subscriber.Subscribe(_ => _assets.LoadSceneAsync("BattleRoom"));
            }

            public void Dispose()
            {
                _disposable.Dispose();
            }
        }
    }
}
using GameScripts.Aot.Systems.Fsm.Abstracts;
using GameScripts.HotUpdate.Systems.Assets;
using GameScripts.HotUpdate.Systems.Fsm;
using GameScripts.HotUpdate.Systems.Log;
using GameScripts.HotUpdate.Systems.UI;
using GameScripts.HotUpdate.UpdateAssets;
using GameScripts.HotUpdate.UpdateAssets.UI.Panels;
using VContainer;
using VContainer.Unity;
using YooAsset;

namespace GameScripts.HotUpdate
{
    public class UpdateAssetsScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterInstance(YooAssets.GetPackage("DefaultPackage"));
            //注册UI系统
            builder.Register<UIUtilities>(Lifetime.Singleton);
            builder.Register<IUI, UI>(Lifetime.Singleton);
            //注册消息系统
            builder.RegisterMessageSystem();
            //注册状态机生成器
            builder.Register<IFsmCreator, FsmCreator>(Lifetime.Singleton);
            //注册资源系统
            builder.Register<IAssets, Assets>(Lifetime.Singleton);
            //注册日志系统
            builder.Register<ILog, Log>(Lifetime.Singleton);

            //入口点
            builder.RegisterEntryPoint<HotUpdateEntry>(Lifetime.Singleton);
        }
    }

    public class HotUpdateEntry : IStartable, ITickable
    {
        [Inject] private IUI _ui;
        [Inject] private IFsmCreator _fsmCreator;
        

        public void Start()
        {
            _fsmCreator.Create("UpdateAssets").Run();
        }

        public void Tick()
        {
        }
    }
}
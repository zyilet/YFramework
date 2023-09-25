using System;
using MessagePipe;
using VContainer;

namespace GameScripts.HotUpdate.UpdateAssets
{
    public struct TestMessage
    {
        public int Number { get; set; }
    }
    
    /// <summary>
    /// 游戏更新阶段、进度改变
    /// </summary>
    public struct UpdateProgressChange
    {
        public string UpdatePhase { get; set; }
        public float Value { get; set; }
    }

    public struct UpdateResourceFailedInfo
    {
        public string Info { get; set; }
        public Action Callback { get; set; }
    }

    public static class MessagePepiExtensions
    {
        public static void RegisterMessageSystem(this IContainerBuilder builder, Action<MessagePipeOptions> configSetter = null)
        {
            //注册MessagePipe，返回MessagePipeOptions
            var options = builder.RegisterMessagePipe();
            configSetter?.Invoke(options);
            //为GlobalMessagePipe设置Provider才能使用诊断信息页面和在DI之外使用消息管道
            builder.RegisterBuildCallback(container => GlobalMessagePipe.SetProvider(container.AsServiceProvider()));

            //注册brokers
            RegisterMessageBroker<TestMessage>();
            RegisterMessageBroker<UpdateProgressChange>();
            RegisterMessageBroker<UpdateResourceFailedInfo>();
            return;

            void RegisterMessageBroker<T>()
            {
                builder.RegisterMessageBroker<T>(options);
            }
        }
    }
}
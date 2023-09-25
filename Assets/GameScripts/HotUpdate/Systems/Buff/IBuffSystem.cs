using VContainer;

namespace GameScripts.HotUpdate.Systems.Buff
{
    public interface IBuffSystem
    {
        void AddBuff<TBuff>() where TBuff : Buff;
        void RemoveBuff<TBuff>() where TBuff : Buff;
        bool ContainsBuff<TBuff>() where TBuff : Buff;
    }

    public class BuffSystem : IBuffSystem
    {
        public void AddBuff<TBuff>() where TBuff : Buff
        {
            throw new System.NotImplementedException();
        }

        public void RemoveBuff<TBuff>() where TBuff : Buff
        {
            throw new System.NotImplementedException();
        }

        public bool ContainsBuff<TBuff>() where TBuff : Buff
        {
            throw new System.NotImplementedException();
        }
    }
    

    public interface IBuff
    {
        void AddBuffBehavior();
    }

    public abstract partial class Buff: IBuff
    {
        
        public void AddBuffBehavior()
        {
            
        }
    }

    public abstract partial class Buff
    {
        public class EnhanceDamage : Buff
        {
            
        }
        
        public class Recover : Buff
        {
            
        }
        public class Corrosion : Buff
        {
            
        }
        public class Suffering : Buff
        {
            
        }
    }

    public interface IBuffBehavior
    {
    }

    public class Test
    {
        private void Main()
        {
            var buffSystem = new BuffSystem();
            buffSystem.AddBuff<Buff.EnhanceDamage>();
        }
    }

    namespace VContainer
    {
        public static class ContainerBuilderExtensions
        {
            public static void RegisterBuffSystem(this IContainerBuilder builder)
            {
                builder.Register<IBuffSystem, BuffSystem>(Lifetime.Singleton);
                builder.Register<Buff.EnhanceDamage>(Lifetime.Transient);
                builder.Register<Buff.Recover>(Lifetime.Transient);
                builder.Register<Buff.Corrosion>(Lifetime.Transient);
                builder.Register<Buff.Suffering>(Lifetime.Transient);
            }
        }
    }

    // #region BuffTest
    //
    // #region buff系统结构
    // //buff行为
    // public interface IBuffBehavior
    // {
    //     void OnActive(IBuffOwner buffOwner);
    // }
    // //buff持有者
    // public interface IBuffOwner
    // {
    // }
    // //buff类
    // public class Buff
    // {
    //     private List<IBuffBehavior> _buffBehaviors;
    //     private IBuffOwner _buffOwner;
    //
    //     public void OnUpdate()
    //     {
    //         foreach (var buffBehavior in _buffBehaviors)
    //         {
    //             buffBehavior.OnActive(_buffOwner);
    //         }
    //     }
    // }
    // #endregion
    //
    // #region buff逻辑实现
    // //眩晕，只能作用于玩家
    // public interface IDizzinessBuffBehavior : IBuffBehavior
    // {
    //     void IBuffBehavior.OnActive(IBuffOwner buffOwner)
    //     {
    //         (buffOwner as IDizzinessBuffBehavior)?.DizzinessSelf();
    //     }
    //
    //     void DizzinessSelf();
    // }
    // /// 玩家
    // public class Player : IBuffOwner, IDizzinessBuffBehavior
    // {
    //     public void DizzinessSelf() //实现眩晕行为
    //     {
    //         //眩晕自己的逻辑
    //     }
    // }
    // //提高伤害，只能作用于武器
    // public interface IEnhanceDamageBuffBehavior : IBuffBehavior
    // {
    //     void IBuffBehavior.OnActive(IBuffOwner buffOwner)
    //     {
    //         (buffOwner as IEnhanceDamageBuffBehavior)?.EnhanceDamage();
    //     }
    //
    //     void EnhanceDamage();
    // }
    // /// 武器
    // public class Weapon : IBuffOwner, IEnhanceDamageBuffBehavior
    // {
    //     public void EnhanceDamage() //实现增加伤害的逻辑
    //     {
    //         //提升武器伤害的逻辑
    //     }
    // }
    // #endregion
    //
    // #endregion
}
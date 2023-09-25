namespace GameScripts.Aot.Systems.Fsm.Abstracts
{
    public interface IFsmRunner
    {
        void SetOwner();
        void Run();
        void Pause();
        void Stop();
    }

    public interface IFsmCreator
    {
        IFsmRunner Create(string graphLocation);
    }
}
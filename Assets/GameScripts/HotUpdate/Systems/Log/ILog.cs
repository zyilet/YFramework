namespace GameScripts.HotUpdate.Systems.Log
{
    public interface ILog
    {
        void LogInfo(string info);
        void LogWarning(string warning);
        void LogError(string error);
    }
}
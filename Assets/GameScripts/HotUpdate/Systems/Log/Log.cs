using UnityEngine;

namespace GameScripts.HotUpdate.Systems.Log
{
    public class Log : ILog
    {
        public void LogInfo(string info)
        {
            Debug.Log(info);
        }

        public void LogWarning(string warning)
        {
            Debug.Log(warning);
        }

        public void LogError(string error)
        {
            Debug.Log(error);
        }
    }
}
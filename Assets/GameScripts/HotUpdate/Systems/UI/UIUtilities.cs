using GameScripts.HotUpdate.Systems.Log;
using UnityEngine;
using VContainer;

namespace GameScripts.HotUpdate.Systems.UI
{
    public class UIUtilities
    {
        [Inject] private ILog _log;

        public GameObject FindCanvas()
        {
            var canvasGameObj = Object.FindObjectOfType<Canvas>().gameObject;

            if (canvasGameObj == null)
                _log.LogError("场景中没有canvas实例");

            return canvasGameObj;
        }

        public GameObject FindUIGameObjInChildren(GameObject panel, string targetUIName)
        {
            var transforms = panel.GetComponentsInChildren<Transform>();
            foreach (var transform in transforms)
            {
                if (transform.name == targetUIName)
                    return transform.gameObject;
            }

            _log.LogWarning($"在[{panel.name}]下没有[{targetUIName}]对象");
            return null;
        }

        public T GetOrAddComponent<T>(GameObject uiGameObj) where T : Component
        {
            var component = uiGameObj.GetComponent<T>();
            
            if (component == null)
                component = uiGameObj.AddComponent<T>();

            return component;
        }
    }
}
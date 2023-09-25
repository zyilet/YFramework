using UnityEngine;

namespace GameScripts.HotUpdate.Extensions
{
    public static class GameObjectExtensions
    {
        public static TComponent FindComponentWithGameObjNameInChildren<TComponent>(this GameObject gameObj, string name)
            where TComponent : Component
        {
            TComponent component = null;
            var transforms = gameObj.GetComponentsInChildren<Transform>();
            foreach (var transform in transforms)
            {
                if (transform.name == name)
                {
                    component = transform.GetComponent<TComponent>();
                }

                if (component != null)
                    break;
            }

            return component;
        }
    }
}
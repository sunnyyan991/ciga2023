using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Logic
{

    public static class ObjectExtensions
    {
        public static T GetNeedComponent<T>(this GameObject go) where T : Component
        {
            if(go == null)
            {
                return null;
            }
            T rlt = null;
            if(!go.TryGetComponent<T>(out rlt))
            {
                rlt = go.AddComponent<T>();
            }
            return rlt;
        }

        public static T GetNeedComponent<T>(this Component component) where T : Component
        {
            if (component == null)
            {
                return null;
            }
            T rlt = null;
            if (!component.TryGetComponent<T>(out rlt))
            {
                rlt = component.gameObject.AddComponent<T>();
            }
            return rlt;
        }
    }
}

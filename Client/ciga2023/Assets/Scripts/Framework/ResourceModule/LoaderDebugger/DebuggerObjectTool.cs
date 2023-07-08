using System;
using System.Collections.Generic;
using UnityEngine;

namespace Framework
{
    /// <summary>
    /// 专门用于资源Debugger用到的父对象自动生成
    /// DebuggerObject - 用于管理虚拟对象（只用于显示调试信息的对象）
    /// </summary>
    public class DebuggerObjectTool
    {
        private static readonly Dictionary<string, Transform> Parents = new Dictionary<string, Transform>();
        private static readonly Dictionary<string, int> Counts = new Dictionary<string, int>(); // 数量统计...

        private static string GetUri(string bigType, string smallType)
        {
            var uri = string.Format("{0}/{1}", bigType, smallType);
            return uri;
        }

        /// <summary>
        /// 设置某个物件，在指定调试组下
        /// </summary>
        /// <param name="bigType"></param>
        /// <param name="smallType"></param>
        /// <param name="obj"></param>
        public static void SetParent(string bigType, string smallType, GameObject obj)
        {
            var uri = GetUri(bigType, smallType);
            Transform theParent = GetParent(bigType, smallType);

            int typeCount;
            if (!Counts.TryGetValue(uri, out typeCount))
            {
                Counts[uri] = 0;
            }
            typeCount = ++Counts[uri];

            try
            {
                Tool.SetChild(obj, theParent.gameObject);
            }
            catch (Exception e)
            {
                Log.Error(string.Format("[SetParent]{0}->{1}->{2}", bigType, smallType, e.Message));
            }

            theParent.gameObject.name = GetNameWithCount(smallType, typeCount);
        }

        public static void RemoveFromParent(string bigType, string smallType, GameObject obj)
        {
            if (!CacheBehaviour.IsApplicationQuited)
            {
                if (obj != null)
                    GameObject.Destroy(obj);

                var newCount = --Counts[GetUri(bigType, smallType)];

                var parent = GetParent(bigType, smallType);
                parent.name = GetNameWithCount(smallType, newCount);
            }
        }

        /// <summary>
        /// 设置Parent名字,带有数量
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="smallType"></param>
        /// <param name="count"></param>
        protected static string GetNameWithCount(string smallType, int count)
        {
            return string.Format("{0}({1})", smallType, count);
        }

        protected static Transform GetParent(string bigType, string smallType)
        {
            var uri = GetUri(bigType, smallType);
            Transform theParent;

            if (!Parents.TryGetValue(uri, out theParent))
            {
                var bigTypeObjName = string.Format("__{0}__", bigType);
                var bigTypeObj = GameObject.Find(bigTypeObjName) ?? new GameObject(bigTypeObjName);
                GameObject.DontDestroyOnLoad(bigTypeObj);
                bigTypeObj.transform.SetAsFirstSibling();

                theParent = new GameObject(smallType).transform;
                Tool.SetChild(theParent, bigTypeObj.transform);
                Parents[uri] = theParent;
            }
            return theParent;
        }

    }
}

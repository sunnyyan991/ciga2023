using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;
#endif

namespace Framework
{
    /// <summary>
    /// Hierarchy层级面板
    /// </summary>
    public static class EditorHierarchyExtensions
    {
        [MenuItem("GameObject/CopyHierarchyPath(Ctrl G) %G", priority = 0)]
        public static void CopyHierarchyPath()
        {
            GameObject go = Selection.activeGameObject;
            if (go != null)
            {
                Undo.RecordObject(go, "Ctrl Z");
                string path = string.Empty;
                path = FullHierarchyPath(go);
                GUIUtility.systemCopyBuffer = path;
            }
        }

        public static string FullHierarchyPath(GameObject go)
        {
            if(go == null)
            {
                return null;
            }

            List<string> paths = new List<string>();
            var t = go.transform;
            while (t != null)
            {
                paths.Add(t.name);
                t = t.parent;
            }
            string result = "";
            for (int i = paths.Count - 2; i >= 0; --i)
            {
                result = result + paths[i];
                if (i != 0)
                {
                    result = result + "/";
                }
            }
            return result;
        }
    }
}

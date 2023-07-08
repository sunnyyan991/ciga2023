using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Logic
{
    public class FightMono : MonoBehaviour
    {
        private Transform LevelParent;

        #region lifeCycle
        private void Awake()
        {
            LevelParent = transform.Find("LevelParent");
            
        }
        private void Start()
        {
            LoadingLevel();
        }
        void Update()
        {
        }
        #endregion

        private void LoadingLevel()
        {
            ClearLevel();
            string prefabAddr = FightManager.Instance.GetLevelPrefabPath();
            var obj = Resources.Load(prefabAddr);
            var go = GameObject.Instantiate(obj) as GameObject;
            go.transform.SetParent(LevelParent);
            FightManager.Instance.EnterLevel();
        }

        private void ClearLevel()
        {
            if (LevelParent != null && LevelParent.childCount > 0)
            {
                int count = LevelParent.childCount;
                for (int i = count - 1; i >= 0; i--)
                {
                    Destroy(LevelParent.GetChild(i).gameObject);
                }
            }
        }
    }
}

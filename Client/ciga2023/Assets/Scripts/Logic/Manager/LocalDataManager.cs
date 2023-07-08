using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Framework;

namespace Logic
{
    public class LocalDataManager : BaseManager<LocalDataManager>
    {

        //public enum EEvents
        //{
        //    onEvent,
        //}
        //EventEmitter<EEvents> eventEmitter = new EventEmitter<EEvents>();


        #region lifeCycle
        public override void OnInit()
        {

        }
        public override void OnDestroy()
        {

        }
        #endregion

        #region func
        /// <summary>
        /// 设置本地存储值 useId试用角色ID做前缀
        /// </summary>
        public void SetIntLocalData(string key, int value, bool useID = true)
        {
            string realKey = GetRealKey(key, useID);
            PlayerPrefs.SetInt(realKey, value);
        }
        /// <summary>
        /// 读取本地存储值
        /// </summary>
        public int GetIntLocalData(string key, bool useID = true)
        {
            string realKey = GetRealKey(key, useID);
            if (PlayerPrefs.HasKey(realKey))
            {
                return PlayerPrefs.GetInt(realKey);
            }
            else
            {
                Log.Error("本地存储未找到 " + realKey + "对应的value");
            }
            return 0;
        }


        private string GetRealKey(string key,bool useId = true)
        {
            if (useId)
            {
                uint roleId = 0;
                if(roleId > 0)
                {
                    return roleId + key;
                }
                else
                {
                    Log.Warning("本地存储key " + key + " 对应的roleId有误");
                }
            }
            return key;
        }
        #endregion

        #region event
        #endregion

    }
}

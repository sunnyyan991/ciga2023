using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Framework;

namespace Logic
{
    public class FightManager : BaseManager<FightManager>
    {
        /// <summary>
        /// 当前关卡
        /// </summary>
        public int curLevelId = 0;

        public cfg.csvStage.Stage curLevel;

        public enum EEvents
        {
            onEventTrigger,
        }
        public EventEmitter<EEvents> eventEmitter = new EventEmitter<EEvents>();


        #region lifeCycle
        public override void OnInit()
        {

        }
        public override void OnDestroy()
        {

        }
        public void OnUpData()
        {
            //需要继承接口 IManagerUpdateModule 
        }
        #endregion

        #region func

        public void EnterGame()
        {
            curLevelId = 1;
        }

        public void EnterLevel()
        {
            curLevel = CSVManager.CSVData.TbStage.GetOrDefault(curLevelId);
            
        }

        /// <summary>
        /// 获取关卡prefab地址
        /// </summary>
        /// <returns></returns>
        public string GetLevelPrefabPath()
        {
            var level = CSVManager.CSVData.TbStage.GetOrDefault(curLevelId);
            //return level.Map;
            return "Prefab/Levels/LevelPrefab";
        }
        
        public void func()
        {
            eventEmitter.Trigger(EEvents.onEventTrigger);
        }
        #endregion

        #region event
        #endregion

    }
}

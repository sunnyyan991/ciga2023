using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Framework;

namespace Logic
{
    /// <summary>
    /// 监听玩家输入的manager
    /// </summary>
    public class InputManager : BaseManager<InputManager>, IManagerUpdateModule
    {
        /// <summary>
        /// 存储按键设置的字典 key 默认按键 value 设置后的按键
        /// </summary>
        private Dictionary<KeyCode, KeyCode> dictKeyTransition = new Dictionary<KeyCode, KeyCode>();


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
            KeyboardInputUpdate();
        }
        #endregion

        #region func
        public void func()
        {
            eventEmitter.Trigger(EEvents.onEventTrigger);
        }

        private void KeyboardInputUpdate()
        {
            if(Input.GetKeyDown(InputKeyTransition(KeyCode.B)))
            {
            }
            
        }
        /// <summary>
        /// 输入key的中转函数
        /// </summary>
        private KeyCode InputKeyTransition(KeyCode curKey)
        {
            if(dictKeyTransition.TryGetValue(curKey,out KeyCode newKey))
            {
                return newKey;
            }
            return curKey;
        }
        #endregion

        #region event
        #endregion

    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Logic
{

    public class UI_FightMain : UIBase
    {
        private Button btnClose;

        private TextMeshProUGUI txtTargetScore;//目标分数
        private TextMeshProUGUI txtTime;//倒计时
        
        #region lifeCycle
        public override void OnOpen(object args)
        {
            //if (args.GetType() == typeof(uint))
            //{
            //    openNum = (uint)args;
            //}
        }
        public override void OnLoaded()
        {
            Parse();
        }
        public override void OnShow()
        {
            UpdateView();
        }
        public override void OnHide()
        {

        }
        public override void OnDestroy()
        {

        }
        public override void OnEventRegister(bool toRegister)
        {

        }
        #endregion 

        #region func
        private void Parse()
        {
            txtTargetScore = transform.Find("Panel/ScoreBg/Score").GetComponent<TextMeshProUGUI>();
            txtTime = transform.Find("Panel/TimeBg/Time").GetComponent<TextMeshProUGUI>();
        }
        private void UpdateView()
        {

        }
        #endregion

        #region event
        private void OnBtnCloseClick()
        {
            this.CloseSelf();
        }
        #endregion
    }

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Logic
{
    public class UI_GameMain : UIBase
    {
        private uint openNum = 0;
        private Button btnStart;
        private Button btnOption;
        private Button btnAbout;

        public override void OnOpen(object args)
        {
            if (args != null && args.GetType() == typeof(uint))
            {
                openNum = (uint)args;
            }
        }

        public override void OnLoaded()
        {
            btnStart = transform.Find("Panel/ButtonList/BtnStart").GetComponent<Button>();
            btnStart.onClick.AddListener(OnBtnStartClick);
        }
        public override void OnShow()
        {
            
        }

        private void OnBtnStartClick()
        {
            Debug.Log("OnBtnStartClick");
            SceneManager.LoadScene("Scenes/FightMain");
            UIManager.OpenUI(EUIID.FightMain);
            this.CloseSelf();
        }
        private void OnBtnOptionClick()
        {
            SoundManager.Instance.Play(10001);
            Debug.Log("OnBtnOptionClick");
        }
        private void OnBtnAboutClick()
        {
        }
    }
}
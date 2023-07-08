using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Logic
{
    /// <summary>
    /// UI点击监听器 实现IPointerClickHandler接口的中间件
    /// </summary>
    public class ClickPointer : MonoBehaviour, IPointerClickHandler
    {
        private Action actLeftClick;
        private Action actRightClick;
        private void OnDestroy()
        {
            actLeftClick = null;
            actRightClick = null;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (eventData.button == PointerEventData.InputButton.Left)
            {
                actLeftClick?.Invoke();
            }
            else if (eventData.button == PointerEventData.InputButton.Right)
            {
                actRightClick?.Invoke();
            }
        }

        public void RegisterPointerLeftClickEvent(Action act)
        {
            actLeftClick = act;
        }
        public void RegisterPointerRightClickEvent(Action act)
        {
            actRightClick = act;
        }
    }
}

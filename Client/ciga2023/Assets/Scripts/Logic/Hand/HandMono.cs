using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Logic
{
    /// <summary>
    /// 挂载在手上的组件
    /// </summary>
    public class HandMono : MonoBehaviour
    {
        void Update()
        {
            UpdateHandPlace();
        }


        private void UpdateHandPlace()
        {
            Vector3 screenPos = Camera.main.WorldToScreenPoint(this.transform.position);
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = screenPos.z;
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
            transform.position = worldPos;
        }
    }
}

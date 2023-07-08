using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Logic
{
    public class MainCameraMono : MonoBehaviour
    {

        public float followSpeed = 5.0f;
        public Transform PlayerTransform;
        private Vector2 targetPosition;



        private void LateUpdate()
        {
            if (PlayerTransform != null)
            {
                //float nextX = Mathf.Lerp(transform.position.x, PlayerTransform.position.x, 0.9f);
                //float nextY = Mathf.Lerp(transform.position.y, PlayerTransform.position.y, 0.9f); 
                float nextX = PlayerTransform.position.x;
                float nextY = PlayerTransform.position.y;
                transform.position = new Vector3(nextX, nextY, -10);
            }
        }
    }
}


using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Logic
{
    public class LevelMono : MonoBehaviour
    {
        private Transform holeParent;
        private List<GameObject> listHole;

        private void Awake()
        {
            holeParent = transform.Find("HoleList");
            var count = holeParent.childCount;
            for (int i = 0; i < count; i++)
            {
                var go = holeParent.GetChild(i).gameObject;
                listHole.Add(go);
            }
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}

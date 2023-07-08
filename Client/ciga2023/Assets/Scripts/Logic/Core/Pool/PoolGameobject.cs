using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Framework;

namespace Logic
{
    public class PoolGameobject : IPoolable, IPoolType
    {
        protected AssetBundleLoader abLoader;
        /// <summary>
        /// 表现层对象
        /// </summary>
        protected GameObject goCell;
        protected string abPath;

        public bool IsRecycled { get; set; }

        public void OnRecycled()
        {

        }

        public void OnDestroy()
        {
            if (abLoader != null)
            {
                abLoader.Release();
                abLoader = null;
            }
            if (goCell != null)
            {
                GameObject.Destroy(goCell);
                goCell = null;
            }
        }

        public virtual void Recycle2Cache()
        {
            if (goCell != null)
            {
                goCell.transform.localPosition = new Vector3(999, 999, 0);
            }
        }
    }
}

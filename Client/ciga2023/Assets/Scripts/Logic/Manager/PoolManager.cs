using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Framework;

namespace Logic
{
    
    public class PoolManager : BaseManager<PoolManager>
    {
        /// <summary>
        /// 存储需要额外加载prefab的地表对象prefab key:SurficialId
        /// </summary>
        private Dictionary<int, RepeatableObjectPool<PoolGameobject>> dictSurficialPrefab = new Dictionary<int, RepeatableObjectPool<PoolGameobject>>();

        #region lifeCycle
        public override void OnInit()
        {

        }
        public override void OnDestroy()
        {
            ClearSurficialPool();
        }

        #endregion
        /// <summary>
        /// 从对象池获取地表对象Prefab
        /// </summary>
        /// <returns></returns>
        public PoolGameobject AllocSurficialPrefab(int surficialId)
        {

            return null;
        }
        /// <summary>
        /// 回收地表对象Prefab
        /// </summary>
        /// <param name="surficialId"></param>
        /// <param name="pgo"></param>
        public void RecycleSurficialPrefab(int surficialId, PoolGameobject pgo)
        {
            if (dictSurficialPrefab.TryGetValue(surficialId, out RepeatableObjectPool<PoolGameobject> pool))
            {
                pool.Recycle(pgo);
            }
            else
            {
                pgo.OnDestroy();
                //直接销毁
                Log.Error("地表对象Prefab回收异常 " + surficialId.ToString());
            }
        }
        /// <summary>
        /// 清理地表prefab池
        /// </summary>
        public void ClearSurficialPool()
        {
            foreach (var pool in dictSurficialPrefab.Values)
            {
                pool.Clear();
            }
            dictSurficialPrefab.Clear();
        }
    }
}

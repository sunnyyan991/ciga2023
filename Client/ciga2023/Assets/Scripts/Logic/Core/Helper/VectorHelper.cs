using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Logic
{
    /// <summary>
    /// 提供向量坐标相关方法的helper类
    /// </summary>
    public class VectorHelper
    {
        /// <summary>
        /// 获取压缩坐标 
        /// </summary>
        public static ulong GetCondensedVector2(float vecX,float vecY)
        {
            return ((ulong)Mathf.FloorToInt(vecX) << 32) | (uint)Mathf.FloorToInt(vecY);
        }
        /// <summary>
        /// 获取压缩坐标 
        /// </summary>
        public static ulong GetCondensedVector2(Vector2 vec)
        {
            return GetCondensedVector2(vec.x,vec.y);
        }
        /// <summary>
        /// 获取解压后的坐标 
        /// </summary>
        public static Vector2 GetVecter2ByCondensed(ulong condensedVec)
        {
            var vecY = condensedVec & 0xffffffff;
            var vecX = (condensedVec - vecY) >> 32;
            return new Vector2(vecX, vecY);
        }
    }
}
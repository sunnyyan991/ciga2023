using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Logic
{
    /// <summary>
    /// 封装框架层的对象池
    /// </summary>
    public class ObjectPool<T> : Framework.ObjectPool<T> where T : IPoolable, new()
    {

    }

    /// <summary>
    /// 封装框架层的可重复对象池
    /// </summary>
    public class RepeatableObjectPool<T> : Framework.RepeatableObjectPool<T> where T : IPoolable, new()
    {

    }
}
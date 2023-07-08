using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

namespace Framework
{

    public class MathTool
    {
        public static int randomSeed = 0;

        /// <summary>
        /// 能够包含最大值(真随机)
        /// </summary>
        public static int GetRandom(int min, int max)
        {
            Random r = new Random(Guid.NewGuid().GetHashCode());
            return r.Next(min, max + 1);
        }

        /// <summary>
        /// 能够包含最大值(真随机)
        /// </summary>
        public static int GetRandom(int max)
        {
            Random r = new Random(Guid.NewGuid().GetHashCode());
            return r.Next(max + 1);
        }

        /// <summary>
        /// 能够包含最大值(使用种子)
        /// </summary>
        public static int GetRandomBySeed(int max, int seed)
        {
            Random r = new Random(seed);
            return r.Next(max + 1);
        }

        /// <summary>
        /// 能够包含最大值(使用种子)
        /// </summary>
        public static int GetRandomBySeed(int min, int max, int seed)
        {
            Random r = new Random(seed);
            return r.Next(min, max + 1);
        }



        /// <summary>
        /// 权重计算器 keyList取值列表 wList权重列表
        /// </summary>
        public static int GetWeight(List<int> keyList, List<int> wList)
        {
            if (keyList.Count == wList.Count)
            {
                int sum = 0;
                for (int i = 0; i < wList.Count; i++)
                {
                    sum += wList[i];
                }

                int w = GetRandom(1, sum);
                int deltaW = 0;
                for (int i = 0; i < wList.Count; i++)
                {
                    deltaW += wList[i];
                    if (w <= deltaW)
                    {
                        return keyList[i];
                    }
                }
            }
            else
            {
                Log.Error("权重计算出错，取值列表 和 权重列表 长度不相等");
            }

            return 0;
        }

        /// <summary>
        /// 权重计算器 keyList取值列表 wList权重列表 返回key的下标
        /// </summary>
        public static int GetWeight(List<int> keyList, List<int> wList, out int keyIndex)
        {
            if (keyList.Count == wList.Count)
            {
                int sum = 0;
                for (int i = 0; i < wList.Count; i++)
                {
                    sum += wList[i];
                }

                int w = GetRandom(1, sum);
                int deltaW = 0;
                for (int i = 0; i < wList.Count; i++)
                {
                    deltaW += wList[i];
                    if (w <= deltaW)
                    {
                        keyIndex = i;
                        return keyList[i];
                    }
                }
            }
            else
            {
                Log.Error("权重计算出错，取值列表 和 权重列表 长度不相等");
            }

            keyIndex = 0;
            return 0;
        }

        /// <summary>
        /// 权重计算器 keyList取值列表 wList权重列表 使用种子
        /// </summary>
        public static int GetWeight(List<int> keyList, List<int> wList, int seed)
        {
            if (keyList.Count == wList.Count)
            {
                int sum = 0;
                for (int i = 0; i < wList.Count; i++)
                {
                    sum += wList[i];
                }

                int w = GetRandomBySeed(1, sum, seed);
                int deltaW = 0;
                for (int i = 0; i < wList.Count; i++)
                {
                    deltaW += wList[i];
                    if (w <= deltaW)
                    {
                        return keyList[i];
                    }
                }
            }
            else
            {
                Log.Error("权重计算出错，取值列表 和 权重列表 长度不相等");
            }

            return 0;
        }

        /// <summary>
        /// 随机获取列表中的一个值
        /// </summary>
        public static int GetRadomListValue(List<int> keyList)
        {
            if (keyList != null && keyList.Count > 0)
            {
                int index = GetRandom(0, keyList.Count - 1);
                return keyList[index];
            }

            return 0;
        }

        /// <summary>
        /// 获取合并坐标 x左移 32 + y;
        /// </summary>
        public static ulong GetMergeVector2(int x, int y)
        {
            return (ulong)x << 32 ^ (uint)y;
        }

        /// <summary>
        /// 获取拆解坐标的 X
        /// </summary>
        public static int GetSplitVector2X(ulong mergeVec)
        {
            return (int)(mergeVec >> 32);
        }

        /// <summary>
        /// 获取拆解坐标的 Y
        /// </summary>
        public static int GetSplitVector2Y(ulong mergeVec)
        {
            return (int)(mergeVec);
        }

        /// <summary>
        /// 输出2进制字符串
        /// </summary>
        public static void UlongToBinary(ulong n)
        {
            string d = Convert.ToString((long)n, 2).PadLeft(4, '0');
        }
    }
}
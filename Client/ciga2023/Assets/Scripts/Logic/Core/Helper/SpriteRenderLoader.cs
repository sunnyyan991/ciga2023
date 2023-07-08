using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using Framework;

namespace Logic
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class SpriteRenderLoader : MonoBehaviour
    {
        private AssetBundleLoader abLoader;

        private SpriteRenderer spr;
        private Sprite sp;

        private ELoadType lastLoadType = ELoadType.None;

        private string curAtlasName;
        private string curSpriteName;

        public enum ELoadType
        {
            None = 0,
            Atlas = 1,
            Sprite = 2,
        }

        private void Awake()
        {
            if (TryGetComponent<SpriteRenderer>(out spr))
            {
                if (spr.sprite == null)
                {
                    spr.enabled = false;
                }
            }
            else
            {
                Log.Error("SpriteRenderLoader 对象 {0} 获取SpriteRenderer失败", name);
            }
        }

        private void OnDestroy()
        {
            ReleaseAsset();
        }

        /// <summary>
        /// 加载sprite 如果是图集里的图片，spriteName为精灵名，如果是非图集图片，spriteName需要包含非图集资源下的文件夹路径
        /// </summary>
        public void LoadSprite(string atlasName, string spriteName)
        {
            if (string.Equals(curAtlasName, atlasName, StringComparison.Ordinal) && string.Equals(curSpriteName, spriteName, StringComparison.Ordinal))
            {
                return;
            }

            ELoadType curLoadType = ELoadType.None;
            if (string.IsNullOrWhiteSpace(spriteName))
            {
                atlasName = null;
            }
            else
            {
                curLoadType = string.IsNullOrWhiteSpace(atlasName) ? ELoadType.Sprite : ELoadType.Atlas;
            }

            //判断资源是否需要重新加载
            bool needReload = false;
            if(curLoadType != lastLoadType)
            {
                needReload = true;
            }
            else
            {
                if(curLoadType == ELoadType.Atlas)
                {
                    if (!atlasName.Equals(curAtlasName))
                    {
                        needReload = true;
                    }
                }
                else if (curLoadType == ELoadType.Sprite)
                {
                    if (!spriteName.Equals(curSpriteName))
                    {
                        needReload = true;
                    }
                }
            }

            curAtlasName = atlasName;
            curSpriteName = spriteName;

            if (needReload)
            {
                ReleaseAsset();
                lastLoadType = curLoadType;
                if (curLoadType == ELoadType.Atlas)
                {
                    var abPath = "Atlas/" + curAtlasName;
                    abLoader = AssetBundleLoader.Load(abPath, (isOk, ab) =>
                    {
                        if (isOk)
                        {
                            UpdateAtlasSprite(ab);
                        }
                    });
                }
                else if (curLoadType == ELoadType.Sprite)
                {
                    var abPath = "SpriteTexture/" + curSpriteName;
                    abLoader = AssetBundleLoader.Load(abPath, (isOk, ab) =>
                    {
                        if (isOk)
                        {
                            UpdateSprite(ab);
                        }
                    });
                }
            }
            else if (curLoadType == ELoadType.Atlas && abLoader != null && abLoader.IsCompleted && abLoader.ResultObject != null)
            {
                UpdateAtlasSprite(abLoader.ResultObject as AssetBundle);
            }
        }


        private void UpdateAtlasSprite(AssetBundle ab)
        {
            var atlas = ab.LoadAsset<SpriteAtlas>(curAtlasName);
            if (atlas != null)
            {
                if (spr != null)
                {
                    spr.enabled = true;
                    if (sp != null)
                    {
                        DestroyImmediate(sp);
                    }
                    spr.sprite = sp = atlas.GetSprite(curSpriteName);
                    if (sp == null)
                    {
                        Log.Error("SpriteRenderLoader {0} GetSprite失败 atlas {1} sprite {2}", name, curAtlasName, curSpriteName);
                    }
                }
                else
                {
                    Log.Error("SpriteRenderLoader {0} SpriteRender获取失败 atlas {1} sprite {2}", name, curAtlasName, curSpriteName);
                }
            }
            else
            {
                Log.Error("SpriteRenderLoader {0} atlas获取失败 atlas {1} sprite {2}", name, curAtlasName, curSpriteName);
            }
        }

        private void UpdateSprite(AssetBundle ab)
        {
            //包内文件需要去掉前缀路径，只取文件名
            var nameList = curAtlasName.Split("/");
            var abName = nameList[nameList.Length - 1];
            var sprite = ab.LoadAsset<Sprite>(abName);
            if (sprite != null)
            {
                if (spr != null)
                {
                    spr.enabled = true;
                    spr.sprite = sprite;
                }
                else
                {
                    Log.Error("SpriteRenderLoader {0} SpriteRender获取失败 sprite {1}", name, curSpriteName);
                }
            }
            else
            {
                Log.Error("SpriteRenderLoader {0} sprite获取失败 sprite {1}", name, curSpriteName);
            }
        }
        private void ReleaseAsset()
        {
            if(spr != null)
            {
                spr.sprite = null;
                spr.enabled = false;
            }
            if (sp != null)
            {
                DestroyImmediate(sp);
            }
            sp = null;

            if (abLoader != null)
            {
                abLoader.Release();
                abLoader = null;
            }
            lastLoadType = ELoadType.None;
        }
    }
}

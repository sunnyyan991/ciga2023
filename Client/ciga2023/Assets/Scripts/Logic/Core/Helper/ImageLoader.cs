using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.U2D;
using Framework;

namespace Logic
{
    [RequireComponent(typeof(Image))]
    public class ImageLoader : MonoBehaviour
    {
        private AssetBundleLoader abLoader;

        private Image image;
        private Sprite sp;

        private ELoadType lastLoadType = ELoadType.None;

        private string curAtlasName;
        private string curSpriteName;
        private bool needSetNativeSize;

        public enum ELoadType
        {
            None = 0,
            Atlas = 1,
            Sprite = 2,
        }

        private bool CheckImage()
        {
            if (image)
                return true;
            if(TryGetComponent<Image>(out image))
            {
                if(image.sprite == null)
                {
                    image.enabled = false;
                }
                return true;
            }
            else
            {
                Log.Error("ImageLoader 对象 {0} 获取SpriteRenderer失败", name);
            }
            return false;
        }

        private void OnDestroy()
        {
            ReleaseAsset();
        }

        /// <summary>
        /// 加载sprite 如果是图集里的图片，spriteName为精灵名，如果是非图集图片，spriteName需要包含非图集资源下的文件夹路径
        /// </summary>
        public void LoadSprite(string atlasName, string spriteName,bool setNativeSize = false)
        {
            if (string.Equals(curAtlasName, atlasName, StringComparison.Ordinal) && string.Equals(curSpriteName, spriteName, StringComparison.Ordinal))
            {
                return;
            }
            needSetNativeSize = setNativeSize;
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
            if (curLoadType != lastLoadType)
            {
                needReload = true;
            }
            else
            {
                if (curLoadType == ELoadType.Atlas)
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
                if (CheckImage())
                {
                    image.enabled = true;
                    if (sp != null)
                    {
                        DestroyImmediate(sp);
                    }
                    image.sprite = sp = atlas.GetSprite(curSpriteName);
                    if (sp == null)
                    {
                        Log.Error("ImageLoader {0} GetSprite失败 atlas {1} sprite {2}", name, curAtlasName, curSpriteName);
                    }
                    if(needSetNativeSize)
                    {
                        image.SetNativeSize();
                    }
                }
                else
                {
                    Log.Error("ImageLoader {0} SpriteRender获取失败 atlas {1} sprite {2}", name, curAtlasName, curSpriteName);
                }
            }
            else
            {
                Log.Error("ImageLoader {0} atlas获取失败 atlas {1} sprite {2}", name, curAtlasName, curSpriteName);
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
                if (CheckImage())
                {
                    image.enabled = true;
                    image.sprite = sprite;
                    if (needSetNativeSize)
                    {
                        image.SetNativeSize();
                    }
                }
                else
                {
                    Log.Error("ImageLoader {0} SpriteRender获取失败 sprite {1}", name, curSpriteName);
                }
            }
            else
            {
                Log.Error("ImageLoader {0} sprite获取失败 sprite {1}", name, curSpriteName);
            }
        }
        private void ReleaseAsset()
        {
            if (CheckImage())
            {
                image.sprite = null;
                image.enabled = false;
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
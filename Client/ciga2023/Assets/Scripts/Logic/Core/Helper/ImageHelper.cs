using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Framework;

namespace Logic
{
    public class ImageHelper
    {

        public static void SetSprite(SpriteRenderer spr, string atlasName, string spriteName)
        {
            if (spr == null)
            {
                return;
            }
            spr.color = new Color(spr.color.r, spr.color.g, spr.color.b);
            SpriteRenderLoader imageSpriteLoader = spr.GetNeedComponent<SpriteRenderLoader>();
            imageSpriteLoader.LoadSprite(atlasName, spriteName);
        }


        public static void SetSprite(SpriteRenderer spr, int iconId)
        {
            string atlasName = null;
            string spriteName = null;
            var iconData = CSVManager.CSVData.TbIcon.GetOrDefault(iconId);
            if (iconData != null)
            {
                atlasName = iconData.AtlasName;
                spriteName = iconData.IconName;
            }
            else
            {
                Log.Error("ImageHelper Icon表中不存在id为 {0} 的数据", iconId);
            }
            SetSprite(spr, atlasName, spriteName);
        }

        public static void SetIcon(Image image, int iconId, bool setNativeSize = false)
        {
            string atlasName = null;
            string spriteName = null;
            var iconData = CSVManager.CSVData.TbIcon.GetOrDefault(iconId);
            if (iconData != null)
            {
                atlasName = iconData.AtlasName;
                spriteName = iconData.IconName;
            }
            else
            {
                Log.Error("ImageHelper Icon表中不存在id为 {0} 的数据", iconId);
            }
            SetIcon(image, atlasName, spriteName, setNativeSize);
        }

        public static void SetIcon(Image image, string atlasName, string spriteName, bool setNativeSize = false)
        {
            if(image == null)
            {
                return;
            }
            image.color = new Color(image.color.r, image.color.g, image.color.b);
            ImageLoader imageSpriteLoader = image.GetNeedComponent<ImageLoader>();
            imageSpriteLoader.LoadSprite(atlasName, spriteName, setNativeSize);
        }

        public static void SetIcon(Image image, string spriteName, bool setNativeSize = false)
        {
            if (image == null)
            {
                return;
            }
            image.color = new Color(image.color.r, image.color.g, image.color.b);
            ImageLoader imageSpriteLoader = image.GetNeedComponent<ImageLoader>();
            imageSpriteLoader.LoadSprite(null, spriteName, setNativeSize);
        }
    }
}

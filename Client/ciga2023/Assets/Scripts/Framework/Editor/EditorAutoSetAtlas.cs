using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEditor.Build.Reporting;
using UnityEngine;
using UnityEditor.U2D;
using UnityEngine.U2D;


namespace Framework
{
    public class EditorAutoSetAtlas
    {
        private static string _textureParentPath = "Assets/ProjectArt/ImageForAtlas";
        private static string _atlasPath = "Assets/ResourseAB/Atlas/{0}.spriteatlas"; 

        [MenuItem("Framework/AutoSetAtlas")]
        public static void AutoSetAtlas()
        {
            DirectoryInfo direction = new DirectoryInfo(_textureParentPath);
            DirectoryInfo[] folders = direction.GetDirectories("*", SearchOption.TopDirectoryOnly);
            for (int i = 0; i < folders.Length; i++)
            {
                CreateAtlas(folders[i].Name);
            }
            Debug.Log("图集生成生成成功，共创建" + folders.Length + "个图集");
        }


        private static void CreateAtlas(string folderName)
        {
            SpriteAtlas atlas = new SpriteAtlas();

            // 设置参数 
            SpriteAtlasPackingSettings packSetting = new SpriteAtlasPackingSettings()
            {
                blockOffset = 1,
                enableRotation = false,
                enableTightPacking = false,
                padding = 2,
            };
            atlas.SetPackingSettings(packSetting);

            SpriteAtlasTextureSettings textureSetting = new SpriteAtlasTextureSettings()
            {
                readable = false,
                generateMipMaps = false,
                sRGB = true,
                filterMode = FilterMode.Point,
            };
            atlas.SetTextureSettings(textureSetting);

            TextureImporterPlatformSettings platformSetting = new TextureImporterPlatformSettings()
            {
                maxTextureSize = 2048,
                format = TextureImporterFormat.ARGB32,
                //crunchedCompression = true,
                //textureCompression = TextureImporterCompression.Compressed,
                //compressionQuality = 0,
            };
            atlas.SetPlatformSettings(platformSetting);

            AssetDatabase.CreateAsset(atlas, string.Format(_atlasPath, folderName));

            //// 1、添加文件
            //DirectoryInfo dir = new DirectoryInfo(folderPath);
            //// 这里我使用的是png图片，已经生成Sprite精灵了
            //FileInfo[] files = dir.GetFiles("*.png");
            //foreach (FileInfo file in files)
            //{
            //    atlas.Add(new[] { AssetDatabase.LoadAssetAtPath<Sprite>($"{folderPath}/{file.Name}") });
            //}

            // 2、添加文件夹
            string folderPath = _textureParentPath + "/" + folderName;
            Object obj = AssetDatabase.LoadAssetAtPath(folderPath, typeof(Object));
            atlas.Add(new[] { obj });

            AssetDatabase.SaveAssets();
        }
    }
}

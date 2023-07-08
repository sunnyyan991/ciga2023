using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Framework;

namespace Logic
{
    public class LanguageManager : BaseManager<LanguageManager>
    {



        #region lifeCycle
        public override void OnInit()
        {

        }
        public override void OnDestroy()
        {

        }
        public void OnUpData()
        {
            //需要继承接口 IManagerUpdateModule 
        }
        #endregion

        #region func

        #endregion

        #region 语言表
        public string GetContext(int languageId)
        {
            var csvData = CSVManager.CSVData.TbLanguage.GetOrDefault(languageId);
            if (csvData != null)
            {
                return csvData.Value;
            }
            else
            {
                Log.Error("Language表 不存在id", languageId);
#if UNITY_EDITOR
                return languageId.ToString();
#else
                return "";
#endif
            }
        }

        public string GetContext(int languageId, string param)
        {
            var csvData = CSVManager.CSVData.TbLanguage.GetOrDefault(languageId);
            if (csvData != null)
            {
                try
                {
                    string val = string.Format(csvData.Value, param);
                    return val;
                }
                catch (Exception e)
                {
                    Log.Error("LanguageFormatError");
                    Log.LogException(e);
#if UNITY_EDITOR
                    return languageId.ToString();
#else
                return "";
#endif
                }
            }
            else
            {
                Log.Error("Language表 不存在id", languageId);
#if UNITY_EDITOR
                return languageId.ToString();
#else
                return "";
#endif
            }
        }

        public string GetContext(int languageId, string param, string param1)
        {
            var csvData = CSVManager.CSVData.TbLanguage.GetOrDefault(languageId);
            if (csvData != null)
            {
                try
                {
                    string val = string.Format(csvData.Value, param, param1);
                    return val;
                }
                catch (Exception e)
                {
                    Log.Error("LanguageFormatError");
                    Log.LogException(e);
#if UNITY_EDITOR
                    return languageId.ToString();
#else
                return "";
#endif
                }
            }
            else
            {
                Log.Error("Language表 不存在id", languageId);
#if UNITY_EDITOR
                return languageId.ToString();
#else
                return "";
#endif
            }
        }
        public string GetContext(int languageId, string param, string param1, string param2)
        {
            var csvData = CSVManager.CSVData.TbLanguage.GetOrDefault(languageId);
            if (csvData != null)
            {
                try
                {
                    string val = string.Format(csvData.Value, param, param1, param2);
                    return val;
                }
                catch (Exception e)
                {
                    Log.Error("LanguageFormatError");
                    Log.LogException(e);
#if UNITY_EDITOR
                    return languageId.ToString();
#else
                return "";
#endif
                }
            }
            else
            {
                Log.Error("Language表 不存在id", languageId);
#if UNITY_EDITOR
                return languageId.ToString();
#else
                return "";
#endif
            }
        }

        public string GetContext(int languageId,params string[] param)
        {
            var csvData = CSVManager.CSVData.TbLanguage.GetOrDefault(languageId);
            if (csvData != null)
            {
                try
                {
                    string val = string.Format(csvData.Value, param);
                    return val;
                }
                catch (Exception e)
                {
                    Log.Error("LanguageFormatError");
                    Log.LogException(e);
#if UNITY_EDITOR
                    return languageId.ToString();
#else
                return "";
#endif
                }
            }
            else
            {
                Log.Error("Language表 不存在id", languageId);
#if UNITY_EDITOR
                return languageId.ToString();
#else
                return "";
#endif
            }
        }
        #endregion

        #region event
        #endregion

    }
}

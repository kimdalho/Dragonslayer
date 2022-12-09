using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class LangContainer : Singleton<LangContainer>
{
    public TextAsset[] languages;


    Dictionary<string, string> mDictionary = new Dictionary<string, string>();


    public void SetLanguage(LanguageType langType)
    {
        string strasset = "";

        switch (langType)
        {
            case LanguageType.LT_CN:
                strasset = ResourceManager.Instance.dicAssets["cn"].text;
                break;
            case LanguageType.LT_ENG:
                strasset = ResourceManager.Instance.dicAssets["eng"].text;
                break;
            case LanguageType.LT_JP:
                strasset = ResourceManager.Instance.dicAssets["jp"].text;
                break;
            case LanguageType.LT_KOR:
                strasset = ResourceManager.Instance.dicAssets["kor"].text;
                break;
            case LanguageType.LT_NONE:
                break;
            case LanguageType.LT_TW:
                strasset = ResourceManager.Instance.dicAssets["tw"].text;
                break;
        }

        LanguageLoad(strasset);
    }

    void LanguageLoad(string asset)
    {
       byte[] StrByte = System.Text.Encoding.UTF8.GetBytes(asset);
       ByteReader data = new ByteReader(StrByte);
       //여기서 asset을 mDic로 초기화
       mDictionary  = data.ReadDictionary();
    }


    public string GetData(string key)
    {
        string val;
        if(mDictionary.TryGetValue(key,out val))
        {
            return val;
        }
        else
        {
            return key;
        }
    }

    
}

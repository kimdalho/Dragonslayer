
using UnityEngine;


public class GameOption :Singleton<GameOption>
{
    private const string PLAYERPREFS_LANGUAGE = "language";

    public static LanguageType CurrentLanguage = LanguageType.LT_ENG;

    private void Awake()
    {
        
    }

    public void Load()
    {
       CurrentLanguage =  (LanguageType)PlayerPrefs.GetInt(PLAYERPREFS_LANGUAGE, 0);
       LangContainer.Instance.SetLanguage(CurrentLanguage);
    }

    public void Save()
    {
        PlayerPrefs.SetInt(PLAYERPREFS_LANGUAGE, (int)CurrentLanguage);
    }

}

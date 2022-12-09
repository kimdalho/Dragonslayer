using UnityEngine;
using System.IO;

/// <summary>
/// Json���� �����͸� ������ ���� Static Ŭ����
/// </summary>
public static class Jsonparser
{
    static string SAVE_PATH = Application.persistentDataPath + "/saves/";

    private const string MASTERYBOOK_PATH = "TableDatas/masteryBook";
    private const string STATSKILL_PATH = "TableDatas/statSkill";
    private const string UNITINFO_PATH = "TableDatas/unitInfo";
    private const string BOWINFO_PATH = "TableDatas/bowInfo";

    /// <summary>
    /// ������ ����
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="saveData"></param>
    /// <param name="saveFileName"></param>
    public static void SaveJsonFile<T>(T[] saveData, string saveFileName)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.data = saveData;
        string saveJson = JsonUtility.ToJson(wrapper);
        string saveFilePath = SAVE_PATH + saveFileName + ".json";
        File.WriteAllText(saveFilePath, saveJson);
        Debug.Log("Save Success " + saveFilePath);
    }

    /// <summary>
    /// ������ ���Ͽ��� �ε�
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="type"></param>
    /// <returns></returns>
    public static T[] LoadJsonFile<T>(eJsonType type) where T : class
    {
        TextAsset data = ResourceManager.Instance.Load<TextAsset>(GetPath(type));
        T[] LoadData = Read<T>(data.ToString());
        return LoadData;
    }

    /// <summary>
    /// ������ ������ �´� ��� ����
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    private static string GetPath(eJsonType type)
    {
        string Path = "";

        switch (type)
        {
            case eJsonType.MasteryBook:
                Path = MASTERYBOOK_PATH;
                break;
            case eJsonType.statSkill:
                Path = STATSKILL_PATH;
                break;
            case eJsonType.unitInfo:
                Path = UNITINFO_PATH;
                break;
            case eJsonType.bowInfo:
                Path = BOWINFO_PATH;
                break;
            case eJsonType.Unknown:
            default:
                Debug.LogError("�ش� ������ GetPath�� ��ϵǾ������ʽ��ϴ�.");
                break;
        }

        return Path;
    }
    /// <summary>
    /// Json���� ������ �迭�� ������.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="json"></param>
    /// <returns></returns>
    private static T[] Read<T>(string json)
    {
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
        return wrapper.data;
    }

    /// <summary>
    /// �����͸� �迭�� �������� ���� Ŭ����
    /// </summary>
    /// <typeparam name="T"></typeparam>
    private class Wrapper<T>
    {
        public T[] data;
    }
}

using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 추후 에셋번들로 바꿔서 에셋을 로드예정
/// </summary>
public class ResourceManager :Singleton<ResourceManager>
{
    //TODO : 현재 Resources를 가져올때 Transform없음. 경로도 하드코딩임. 수정 요함
    public Dictionary<string, TextAsset> dicAssets;

    /// <summary>
    /// 로드한 데이터 캐쉬화
    /// </summary>
    Dictionary<string, GameObject> dicCache = new Dictionary<string, GameObject>(); 

    public T Load<T>(string path) where T : UnityEngine.Object
    {
        return Resources.Load<T>(path);
    }

    /// <summary>
    /// 게임오브젝트를 생성을 해주는 함수.
    /// </summary>
    /// <param name="path"></param>
    /// <param name="parent"></param>
    /// <returns></returns>
    public GameObject Instantiate(string path, Transform parent = null)
    {
        GameObject original = null;

        //정도 최초 접근시 로드
        if (dicCache.ContainsKey(path) == false)
        {
            original = Load<GameObject>($"Prefabs/{path}");
            dicCache[path] = original;
        }
        else
        {
            original = dicCache[path];
        }

        if (original == null)
        {
            Debug.Log($"Fail to load prefab : {path}");
            return null;
        }

        //원본을 커피하여 생성해줍니다. 
        GameObject go = Instantiate(original, parent);
        go.name = original.name;

        return go;
    }


}
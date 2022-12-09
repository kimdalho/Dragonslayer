using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneInGame : SceneBase
{
    private void Awake()
    {
        SceneContianer.Instance.curScene = eScenes.InGameScene;
        SoundManager.Instance.SetBGM();
    }
}

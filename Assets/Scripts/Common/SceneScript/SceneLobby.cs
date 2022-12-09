using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLobby : SceneBase
{
    private void Awake()
    {
        SceneContianer.Instance.curScene = eScenes.LobbyScene;
        SoundManager.Instance.SetBGM();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{

    //1 ºÒ
    //2 È­»ì

    public static int FIRE = 0;

    public AudioSource audiosource;


    public List<AudioClip> effectClips;


    public Dictionary<eScenes, AudioClip> keyValuePairs= new Dictionary<eScenes, AudioClip>();

    public AudioClip titlebgm;

    public AudioClip lobbybgm;

    public AudioClip ingamebgm;

    private void Awake()
    {
        audiosource = GetComponent<AudioSource>();

        keyValuePairs.Add(eScenes.TitleScene, titlebgm);
        keyValuePairs.Add(eScenes.LobbyScene, lobbybgm);
        keyValuePairs.Add(eScenes.InGameScene, ingamebgm);
    }

    public void SetBGM()
    {
        audiosource.clip =  keyValuePairs[SceneContianer.Instance.curScene];
        audiosource.Play();
    }

}

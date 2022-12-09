using UnityEngine.SceneManagement;

public class SceneContianer : Singleton<SceneContianer>
{
    public eScenes curScene
    {
        get
        {
            return _curScene;
        }
        set
        {
            
            _curScene = value;
            Debug.Log("xx" +_curScene +  ++cnt);
        }
    }

    private int cnt = 0;
    private eScenes _curScene;


    public string cash;
    public void LoadScene(eScenes loadScene)
    {
        switch(loadScene)
        {
            case eScenes.TitleScene:
                curScene = eScenes.TitleScene;
                break;
            case eScenes.LobbyScene:

                curScene = eScenes.LobbyScene;
                cash = "3.LobbyScene";
                
                break;
            case eScenes.InGameScene:
                curScene = eScenes.InGameScene;
                //cash = "4.GameScene";
                cash = "3DMap";
                break;
        }
        SceneLoading.str = cash;
        SceneManager.LoadScene("2.LodingScene");
    }
}

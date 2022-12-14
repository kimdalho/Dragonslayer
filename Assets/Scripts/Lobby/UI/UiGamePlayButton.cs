using UnityEngine.UI;
using TMPro;
public class UiGamePlayButton : UI_Base
{
    public enum eImages
    {
        BUTTON_IMAGE = 0,
        ICON_IMAGE = 1,
    }
    public enum eTMPs
    {
        PLAY_TMP = 0,
    }

    public override void Init()
    {
        Bind<Image>(typeof(eImages));
        Bind<TextMeshProUGUI>(typeof(eTMPs));
        GetComponent<Button>().onClick.AddListener(OnClickedGameStart);
    }

    public void OnClickedGameStart()
    {
        switch(LobbyUiManager.Instance.curGameType)
        {
            case eGameType.SingleGame:
                SceneContianer.Instance.LoadScene(eScenes.InGameScene);
                break;
            case eGameType.MultyGame:
                SceneContianer.Instance.LoadScene(eScenes.InGamePvPScene);
                break;
        }
        
    }
}


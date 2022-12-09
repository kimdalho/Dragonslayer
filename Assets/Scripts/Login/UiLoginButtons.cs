using UnityEngine;
using UnityEngine.UI;

enum eLoginType
{
    None = 0,
    Google = 1,
    FaceBook = 2,
    Email = 3,
    Guest = 4,
}

/// <summary>
/// 로그인을 하는데 사용되는 버튼들
/// </summary>
public class UiLoginButtons : MonoBehaviour
{
    [SerializeField] Button gpgsbutton;
    [SerializeField] Button facebookbutton;
    [SerializeField] Button gamecenterbutton;
    [SerializeField] Button guestbutton;

    //이걸 유저데이터로 취급해야할지 고민해봐야한다.
    eLoginType curLoginType;

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        gamecenterbutton.onClick.AddListener(OnClickedGamecenterButton);
        facebookbutton.onClick.AddListener(OnClickedFacebookButton);
        gpgsbutton.onClick.AddListener(OnClickedGPGSButton);
        guestbutton.onClick.AddListener(OnClickedGuestButton);
    }

    private void OnClickedGamecenterButton()
    {
        curLoginType = eLoginType.Email;
        Boot();
    }

    private void OnClickedFacebookButton()
    {
        curLoginType = eLoginType.FaceBook;
        Boot();
    }

    private void OnClickedGPGSButton()
    {
        curLoginType = eLoginType.Google;
        Boot();
    }

    private void OnClickedGuestButton()
    {
        curLoginType = eLoginType.Guest;
        var title = FindObjectOfType<SceneTitle>();
        title.TabToStart();
     }


    private void Boot()
    {
        var panel = ResourceManager.Instance.Instantiate(Global.LoginPanelName, gameObject.transform).GetComponent<UiLgoinPanel>();
        panel.Init();
        
    }

}

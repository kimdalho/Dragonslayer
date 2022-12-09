using UnityEngine;
using UnityEngine.UI;
public class UiLgoinPanel : Base_Panel
{
    [SerializeField] PanelInputField nicknameInputBox;
    [SerializeField] PanelInputField passwordInputBox;
    [SerializeField] Button closeButton;
    [SerializeField] Button loginButton;

    public override void Init()
    {
        nicknameInputBox.Init();
        passwordInputBox.Init();
        closeButton.onClick.AddListener(OnClickedCloseButton);
        loginButton.onClick.AddListener(OnClickedLoginButton);
    }

    public void OnClickedCloseButton()
    {
        Destroy(this.gameObject);
    }

    public void OnClickedLoginButton()
    {

    }



    // 인증을 관리할 객체
   
}

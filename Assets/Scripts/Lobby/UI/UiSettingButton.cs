using UnityEngine.UI;

public class UiSettingButton : BindButton
{
    public override void Init()
    {
        base.Init();
        button.onClick.AddListener(OnClickedButton);
    }

    public override void OnClickedButton()
    {
    }
}

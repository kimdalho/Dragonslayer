using UnityEngine.UI;
using TMPro;
public class PanelInputField : UI_Base   
{
    enum eImages
    {
        InputboxFrame = 1,
    }

    enum eTmps
    {
        older = 1,
        Text = 2,
    }


    public override void Init()
    {
        Bind<Image>(typeof(eImages));
        Bind<TextMeshProUGUI>(typeof(eTmps));
    }

    public TextMeshProUGUI getInputField()
    {
        return Get<TextMeshProUGUI>("Text");
    }
}

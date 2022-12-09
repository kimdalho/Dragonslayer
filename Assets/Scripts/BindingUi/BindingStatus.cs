using UnityEngine.UI;
using TMPro;
public class BindingStatus : Base_Status
{

    private enum eImages
    {
        Icon = 0,
    }

    public override void Init()
    {
        Bind<Image>(typeof(eImages));
        Bind<TextMeshProUGUI>(typeof(eTmps));
        Get<TextMeshProUGUI>("TEXT").text = "0";
    }

    public TextMeshProUGUI GetTmp()
    {
        return Get<TextMeshProUGUI>("TEXT");
    }

    public void SetTmp(string value)
    {
        Get<TextMeshProUGUI>("TEXT").text = value;
    }

    public void SetTmp(float value)
    {
        Get<TextMeshProUGUI>("TEXT").text = value.ToString();
    }

}

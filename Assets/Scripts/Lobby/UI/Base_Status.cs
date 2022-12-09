using UnityEngine.UI;
using TMPro;

public abstract class Base_Status : UI_Base
{
    private enum eImages
    {
        Icon = 0,
        Button_Add = 1,
        min_icon = 2,
    }

    protected enum eTmps
    {
        TEXT = 0,
    }

    private enum eButtons
    {
        Button_Add = 0,
    }

    

    public override void Init()
    {
        Bind<Image>(typeof(eImages));
        Bind<Button>(typeof(eButtons));
        Bind<TextMeshProUGUI>(typeof(eTmps));

        Get<TextMeshProUGUI>("TEXT").text = "0";
    }

    

}
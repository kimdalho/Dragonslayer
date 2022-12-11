using UnityEngine.UI;
public class UiBackGround : UI_Base
{
    public enum eImages
    {
        BACKGROUND_IMAGE = 0,
    }

    public override void Init()
    {
        Bind<Image>(typeof(eImages));
      //  Debug.Log($"{GetBackGroundImage().name} I'm in here");
    }

   

}


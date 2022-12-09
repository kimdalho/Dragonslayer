using UnityEngine;
using UnityEngine.UI;

public class UiToggle : UI_Base
{

    [SerializeField] Toggle toggle;

    [SerializeField] GameObject On_Label;
    [SerializeField] GameObject Off_Label;
    [SerializeField] GameObject On_Button_Img;
    [SerializeField] GameObject Off_Button_Img;


    private void Start()
    {
        Init();
    }


    public override void Init()
    {
        toggle = GetComponent<Toggle>();
        toggle.onValueChanged.AddListener(OnValueChanged);
    }

    private void OnValueChanged(bool toggleOn)
    {
        On_Label.SetActive(toggleOn);
        Off_Label.SetActive(!toggleOn);
        On_Button_Img.SetActive(toggleOn);
        Off_Button_Img.SetActive(!toggleOn);
    }



}

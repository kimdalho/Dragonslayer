using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class CommonPopup : MonoBehaviour
{
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI descText;

    public Button oneOk;
    public Button oneNo;
    public Button towYes;
    public Button towNo;
    public ePopupType type;

    public Dictionary<ePopupType, Action> commopPopup;

    private void Start()
    {
        switch (type)
        {
            case ePopupType.Ok:
                OkTypeSetup();
                break;
            case ePopupType.YesNo:
                YesNoTypeSetup();
                break;
        }
    
    }

    private void OkTypeSetup()
    {
        oneOk.gameObject.SetActive(true);
        oneNo.gameObject.SetActive(false);
        towYes.gameObject.SetActive(false);
        towNo.gameObject.SetActive(false);
    }

    private void YesNoTypeSetup()
    {
        oneOk.gameObject.SetActive(false);
        oneNo.gameObject.SetActive(false);
        towYes.gameObject.SetActive(true);
        towNo.gameObject.SetActive(true);
    }


    public void Close()
    {

    }
}

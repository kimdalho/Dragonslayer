using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 이미지 그리고 하위 객체에 이미지가 있는 타입을 바인딩하기위함
/// </summary>

public class BindImage : UI_Base
{
    public Image frameImage;
    public Image iconImage;

    public override void Init()
    {
        frameImage = GetComponent<Image>();
        iconImage = GetComponentInChildren<Image>();
    }

    public void Hide()
    {
        frameImage.gameObject.SetActive(false);
        iconImage.gameObject.SetActive(false);
    }

    public void Show()
    {
        frameImage.gameObject.SetActive(true);
        iconImage.gameObject.SetActive(true);
    }
}

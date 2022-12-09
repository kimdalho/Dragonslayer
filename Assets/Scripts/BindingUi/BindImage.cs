using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// �̹��� �׸��� ���� ��ü�� �̹����� �ִ� Ÿ���� ���ε��ϱ�����
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

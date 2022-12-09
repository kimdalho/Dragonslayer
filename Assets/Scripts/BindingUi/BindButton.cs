using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
//�� Object�� ��ư ������Ʈ�� Image�� �ִ°�츦 ���ε� �ϱ����ؼ� ǥ����
public class BindButton : UI_Base
{
    protected Image frameImage;
    protected Button button;

    public override void Init()
    {
        button = GetComponent<Button>();
        frameImage = GetComponent<Image>();
    }

    public virtual void Init(Action clickCallback)
    {
        button = GetComponent<Button>();
        frameImage = GetComponent<Image>();
        button.onClick.AddListener(() => { clickCallback.Invoke(); });
    }

    public virtual void OnClickedButton()
    {
        //SoundManager.Instance.audiosource
    }
}

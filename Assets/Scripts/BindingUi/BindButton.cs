using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
//한 Object에 버튼 컴포넌트와 Image가 있는경우를 바인딩 하기위해서 표현함
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

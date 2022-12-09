using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvenButton : BottomButton
{
    public Image img;
    public Button button;
    public Str_ItemInfo itemInfo;

    private void Awake()
    {
        itemInfo = new Str_ItemInfo();
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClickItem);
        
        var go = transform.GetChild(0);
        var itemIcon = go.transform.GetChild(0);
        img = itemIcon.GetComponent<Image>();
        //
        itemInfo.sprite = img.sprite;
        itemInfo.obj = this.gameObject;
        itemInfo.attack = 3;
        itemInfo.range = 3;
        itemInfo.speed = 3;
    }

    private void OnClickItem()
    {
        LobbyUiManager.Instance.equipBuffer.Enqueue(itemInfo);
        gameObject.SetActive(false);
    }


}
[System.Serializable]
public struct Str_ItemInfo
{ 
    public Sprite sprite;
    public int attack;
    public int range;
    public int speed;
    public GameObject obj;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Equip : MonoBehaviour
{
    public bool isUse;

    public Button button;
    public Image img;
    public Str_ItemInfo use_ItemInfo;

    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClickItem);

        var go = transform.GetChild(0);
        var itemIcon = go.transform.GetChild(0);
        img = itemIcon.GetComponent<Image>();
        img.gameObject.SetActive(true);
        img.color = Color.white;
        img.enabled = false;
    }

    public void Set(Str_ItemInfo data)
    {
        use_ItemInfo = data;
        img.sprite = use_ItemInfo.sprite;
        img.enabled = true;
        isUse = true;
    }

    public void OnClickItem()
    {
        use_ItemInfo.obj.SetActive(true);
        img.enabled = false;
        isUse = false;
    }
}

using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public abstract class BaseSkill : ScriptableObject
{
    public Sprite ButtonIconImage;

    public virtual void Get()
    {
        GameManager.Instance.arrowUpgradAction(this);
    }

    public virtual List<GameObject> SettingArrow(List<GameObject> arrowList)
    {
        return null;
    }
}

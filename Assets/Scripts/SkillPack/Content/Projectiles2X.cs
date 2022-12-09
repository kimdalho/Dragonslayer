using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "AttributeScriptable/Projectiles2X", order = 100)]
public class Projectiles2X : BaseSkill
{
    public override void Get()
    {
        base.Get();
        Debug.Log("Projectiles2X");
    }

    public override List<GameObject> SettingArrow(List<GameObject> arrowList)
    {
        foreach (var arrow in arrowList)
        {
            SetSizeUp(arrow);
        }

        return arrowList;
    }

    public void SetSizeUp(GameObject arrow)
    {
        arrow.transform.localScale = new Vector3(2, 2, 2);
    }
}

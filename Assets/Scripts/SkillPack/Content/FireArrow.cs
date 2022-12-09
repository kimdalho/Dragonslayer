using System.Collections.Generic;
using UnityEngine;

public class FireArrow : BaseSkill
{
    public override void Get()
    {
    }


    public override List<GameObject> SettingArrow(List<GameObject> arrowList)
    {
        foreach (var arrow in arrowList)
        {
            MakeFire(arrow);
        }
        return arrowList;
    }

    public void MakeFire(GameObject arrow)
    {
        if (arrow.TryGetComponent<Arrow>(out var arrowSc))
        {
            GameObject fireObject = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            fireObject.transform.localScale = Vector3.one * 3;
            fireObject.transform.parent = arrowSc.ArrowHead.transform;
            fireObject.transform.localPosition = Vector3.zero;
        }
    }
}

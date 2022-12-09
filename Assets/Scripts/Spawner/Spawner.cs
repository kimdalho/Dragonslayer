using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner : InGameStepObject
{
    protected override void OnEnable()
    {

    }

    protected override void OnDestroy()
    {

    }

    protected override void OnGameStart()
    {

    }

    protected override void OnLevelUp()
    {

    }

    protected override void OnSkillSelecte()
    {

    }


    protected override void OnGameOver()
    {

    }


    public virtual GameObject Create(SpawnItemData data)
    {
        GameObject go = ResourceManager.Instance.Instantiate(data.path);
        return go;
    }

    public virtual GameObject Create(Quaternion rot)
    {
        return null;
    }

    public virtual GameObject Create(Vector3 pos, Quaternion rot)
    {
        return null;
    }

    public virtual GameObject Create()
    {
        return null;
    }

    public virtual void Hide()
    {

    }

    public virtual void Show()
    {

    }


}

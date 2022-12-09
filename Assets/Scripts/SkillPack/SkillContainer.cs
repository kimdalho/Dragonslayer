using System;
using System.Collections.Generic;

public class SkillContainer : Singleton<SkillContainer>
{
    public List<BaseSkill> skillList
    {
        get
        {
            return _skillList;
        }
        private set
        {
            _skillList = value;
        }
    }

    [UnityEngine.SerializeField] List<BaseSkill> _skillList;


    public int GetSkillListCount()
    {
        return 5;
    }
}

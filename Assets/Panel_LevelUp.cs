using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Panel_LevelUp : MonoBehaviour
{
    public Button[] buttons;
    const string IconObjectName = "Icon";

    SkillContainer manager;

    public List<int> numberBuffer;
    public Queue<int> outputBuffer;

    const int nowButtonNumber = 3;

    public void Setup()
    {
        Init();
        ResetSkillList();
    }

    public void Init()
    {
        manager = SkillContainer.Instance;
        numberBuffer = new List<int>();
        outputBuffer = new Queue<int>();
    }

    private void ResetSkillList()
    {
        numberBuffer.Clear();
        outputBuffer.Clear();

        for (int i = 0; i < manager.GetSkillListCount(); i++)
        {
            numberBuffer.Add(i);
        }

        while (outputBuffer.Count < nowButtonNumber)
        {
            int rnd = Random.Range(0, manager.GetSkillListCount());
            if (numberBuffer.Contains(rnd))
            {
                numberBuffer.Remove(rnd);
                outputBuffer.Enqueue(rnd);
            }
        }

        for (int i = 0; i < buttons.Length; i++)
        {
            BtnStatusUpdate(i);
        };
    }

    private void ResumeGame()
    {
        GameManager.Instance.SetStep(ePlayStep.step_SKILLSelect);
    }

    private void BtnStatusUpdate(int indexNumber)
    {
        int data_int = outputBuffer.Dequeue();
        //eSkillType skilltype = (eSkillType)data_int;
        //var skill = manager.Create(skilltype);

        var skill = manager.skillList[indexNumber];

        System.Action clickEvent = () => { skill.Get(); };
        buttons[indexNumber].onClick.RemoveAllListeners();
        buttons[indexNumber].onClick.AddListener(() => { clickEvent?.Invoke(); });
        buttons[indexNumber].onClick.AddListener(ResumeGame);
        IconChange(skill, indexNumber);
    }

    private void IconChange(BaseSkill skill, int indexNumber)
    {
        GameObject iconObject = buttons[indexNumber].gameObject.transform.Find(IconObjectName).gameObject;
        if(iconObject == null)
        {
            Debug.LogError("There is no Icon Object!");
            return;
        }

        if(iconObject.TryGetComponent<Image>(out var imageComp))
        {
            imageComp.sprite = skill.ButtonIconImage;
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
public class InGameUiManager : Singleton<InGameUiManager>
{
    public Transform uIroot;

    //나중에 바인딩
    public TextMeshProUGUI expTmp;
    public ExpSlider exSlider;
    public Panel_LevelUp levelUp;

    [Header("연출")]
    [SerializeField]
    private Transform startAnim;

    [SerializeField]
    private GameObject startTmp;

    [SerializeField]
    private Transform gameoverAnim;

    private void OnGameOver()
    {
      StartCoroutine(CoPlayGameOverAnimation());

    }

    private void OnLevelUp()
    {
        InGameUiManager.Instance.exSlider.Zero();
        levelUp.gameObject.SetActive(true);
    }

    private void OnSkillSelecte()
    {
        levelUp.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        Global.inGameStepAction[ePlayStep.step_GameOver] += OnGameOver;
        Global.inGameStepAction[ePlayStep.step_LevelUp] += OnLevelUp;
        Global.inGameStepAction[ePlayStep.step_SKILLSelect] += OnSkillSelecte;

    }

    private void OnDestroy()
    {
        Global.inGameStepAction[ePlayStep.step_GameOver] -= OnGameOver;
        Global.inGameStepAction[ePlayStep.step_LevelUp] -= OnLevelUp;
        Global.inGameStepAction[ePlayStep.step_SKILLSelect] -= OnSkillSelecte;
    }



    public IEnumerator CoPlayStartAnim()
    {
        if (levelUp == null)
            yield break;

        levelUp.Setup();
        startAnim.gameObject.SetActive(true);
        yield return new WaitForSeconds(3f);
        startAnim.gameObject.SetActive(false);
        yield return new WaitForSeconds(1f);
        startTmp.SetActive(true);
        yield return new WaitForSeconds(1f);
        startTmp.SetActive(false);
        yield return new WaitForSeconds(1f);
    }

    public Transform label;
    private IEnumerator CoPlayGameOverAnimation()
    {
        SoundManager.Instance.audiosource.Stop();
        yield return new WaitForSeconds(1f);
        gameoverAnim.gameObject.SetActive(true);

        yield return new WaitForSeconds(3f);
        while(true)
        {
            label.transform.position += Vector3.up;
            yield return new WaitForSeconds(0.1f);
        }
        //시간지나고 리트라이 또는 로비 가는 팝업 호출
    }

}

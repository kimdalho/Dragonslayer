using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : InGameStepObject
{
    private const string FIRE_BALL_STR = "Fireball";
    private const int BASIC_HP = 200;

    [Header("Movement Attribute")]
    public float speed = 5;
    public float rotAngle = 0;
    public float turnSmoothTime = 0.2f;
    public Vector3 forward;
    float turnnSmoothVelocity;

    [Header("Reference")]
    public float inputHorizontal;
    public float inputVertical;

    [Header("Body parts reference")]
    public GameObject upperBody;
    public GameObject lowerBody;
    public GameObject m_inpul_Right;

    [Header("Platform")]
    public bool PC = true;

    [Header("Compo")]
    public CharacterHp hpbar;
    float attackSpeed = 3.0f;
    public ArrowSpawner spawner;


    public void Setup()
    {
        hpbar.Setup(BASIC_HP);
        spawner.Setup();
        StartCoroutine(CoSponeArrow());
        StartCoroutine(CoController());
    }
    protected override void OnLevelUp()
    {
        hpbar.Hill(30);
        StopAllCoroutines();
    }

    protected override void OnGameOver()
    {
        StopAllCoroutines();
    }

    protected override void OnSkillSelecte()
    {
        StartCoroutine(CoSponeArrow());
        StartCoroutine(CoController());
    }

    /// <summary>
    /// 화살생성
    /// </summary>
    /// <returns></returns>
    IEnumerator CoSponeArrow()
    {
        while (true)
        {

            if (spawner.TryGetComponent<ArrowSpawner>(out var arrowSpawner))
            {
                //현재 화살 가져오기
                arrowSpawner.getCurArrow();
            }

            yield return new WaitForSeconds(attackSpeed);
        }
    }

    /// <summary>
    /// 각도 구현
    /// </summary>
    private IEnumerator CoController()
    {
        while (true)
        {
            inputHorizontal = Input.GetAxisRaw("Vertical");

            Vector3 from = new Vector3(0f, 0f, 1f);
            Vector3 to = new Vector3(m_inpul_Right.GetComponent<MobileInputController>().Horizontal, 
                0f, 
                m_inpul_Right.GetComponent<MobileInputController>().Vertical);

            if (m_inpul_Right.GetComponent<MobileInputController>().Horizontal != 0 && 
                m_inpul_Right.GetComponent<MobileInputController>().Vertical != 0)
            {
                float angle = Vector3.SignedAngle(from, to, Vector3.up);
                rotAngle = angle;
                transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, angle, ref turnnSmoothVelocity, turnSmoothTime);
            }
            yield return null;
        }
    }

    void OnParticleCollision(GameObject other)
    {
        switch (other.tag)
        {
            case FIRE_BALL_STR:
                var effect = other.GetComponent<ParticleEffect>();
                hpbar.Hit(effect.attack);
                Destroy(other.gameObject);

                if (hpbar.GetHp() <= 0)
                {
                    GameManager.Instance.SetStep(ePlayStep.step_GameOver);
                }
                break;
        }
    }
}

using UnityEngine;
using System;
using System.Collections.Generic;
using System.Collections;
using static UnityEngine.GraphicsBuffer;
public enum eUnitAiType
{
    None = 0,
    Follow = 1,
    Attack = 2,
    Die = 3,
}

public abstract class BaseUnit : InGameStepObject
{
    [SerializeField]
    protected eUnitAiType curType;
    [SerializeField]
    protected InGameUnitInfo info;
    protected bool die;

    protected const  string AnimAttack = "Attackb";

    [Header("투사체")]
    [SerializeField]
    protected Spawner spawner;

    public CharacterHp hpbar;

    public bool GetDie()
    {
        return die;
    }
    
    public virtual void Setup()
    {

    }

    public virtual void SetInfo()
    {
        info.atk = 10;
        info.def = 3;
        info.dropExp = 3;
        info.speed = 10;
        info.health = 10;
        hpbar.Setup(info.health);
    }


    public void SetInfo(UnitInfoData data)
    {
        info = data.info;
    }

    public InGameUnitInfo GetInfo()
    {
        return info;
    }

    public void SetCurType(eUnitAiType value)
    {
        curType = value;
    }

    public void SetHealth(int value)
    {
        info.health = value;
    }

    public int GetExp()
    {
        if (info.dropExp <= 0)
            info.dropExp = 3;

        return info.dropExp;
    }

    public void SetDead(eUnitAiType type)
    {
        curType = type;
    }


}

public abstract class BaseMonster : BaseUnit, IDontwork
{
    public Animator animator;
    public Rigidbody rb;
    public AudioSource auio;
    public ParticleSystem hitParticle;

    private int dropExp = 10;


    protected override void OnEnable()
    {
        base.OnEnable();
        
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
        GameManager.Instance.aiPlayer.baseMonsters.Remove(this);
        GameManager.Instance.curExp += dropExp;
        InGameUiManager.Instance.exSlider.RefreshUi();
    }

    

    public override void Setup()
    {
        GameManager.Instance.aiPlayer.baseMonsters.Add(this);
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        auio = GetComponent<AudioSource>();
        SetCurType(eUnitAiType.Follow);
        StartCoroutine(CoAiMovement());
    }

    public GameObject target;

    public bool dontMove;
    /// <summary>
    /// 몬스터 행동 정지
    /// </summary>
    public void DontMove()
    {
        dontMove = true;

    }
    /// <summary>
    /// 몬스터 피격
    /// </summary>
    public void Hit(int damage)
    {
        info.health -= damage;

        if(info.health <= 0)
        {
            Destroy(gameObject);
        }
        else
        {

        }
    }
    /// <summary>
    /// 몬스터 이동
    /// </summary>
    /// <returns></returns>
    /// 

    protected virtual IEnumerator CoAiMovement()
    {
        yield return new WaitForSeconds(2.5f);

        while (!die)
        {
            switch (curType)
            {
                case eUnitAiType.Follow:
                    Follow();
                    break;
                case eUnitAiType.Attack:
                    Attack();
                    break;
                case eUnitAiType.Die:
                    animator.SetTrigger("DeadTrg");
                    yield return new WaitForSeconds(1f);
                    Destroy(this.gameObject);
                    break;
            }
            yield return null;
        }
    }

    private void Follow()
    {
        animator.SetBool(AnimAttack, false);
        if (dontMove == true)
        {
            gameObject.SetActive(false);
        }
        else
        {
            if(target == null)
                target = GameManager.Instance.player.gameObject;

            Vector3 dir = GetDir();
            Quaternion _rot = Quaternion.LookRotation(dir);
            transform.root.rotation = _rot;

            //transform.position += (dir * info.speed * Time.deltaTime);
            Vector3 targetPos = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, targetPos, info.speed * Time.deltaTime);
            float distance = GetDistance();
            
            if(distance <= 15)
            {
                SetAnimTypeAttack();
            } 
        }
    }


    private Vector3 GetDir()
    {
        Vector3 targetPos = new Vector3(target.transform.position.x, 0f, target.transform.position.z);
        Vector3 thisPos = new Vector3(transform.position.x, 0f, transform.position.z);
        Vector3 dir = (targetPos - thisPos).normalized;
        this.dir = dir;
        return dir;
    }

    private void Attack()
    {
        rb.velocity = Vector3.zero;
        Vector3 dir = (target.transform.position - transform.position).normalized;
        Quaternion _rot = Quaternion.LookRotation(dir);
        transform.root.rotation = _rot;

        animator.SetBool(AnimAttack, true);

        float distance = GetDistance();

        if(distance > 15)
        {
            SetAnimTypeFollow();
        } 
    }

    public void Anim_AttackEnd()
    {
        spawner.Create(transform.root.rotation);
        auio.clip =  SoundManager.Instance.effectClips[SoundManager.FIRE];
        auio.Play();
    }



    public Vector3 dir;
    public float dis;

    private float GetDistance()
    {
        var a = new Vector2(transform.position.x, transform.position.z);
        var b = new Vector2(target.transform.position.x, target.transform.position.z);

        float distance = Vector2.Distance(a,b);
        dis = distance;
        return distance;
    }


    /// <summary>
    /// 어택으로 바뀌었을 시
    /// </summary>
    public void SetAnimTypeAttack()
    {
       
        curType = eUnitAiType.Attack;

    }

    public void SetAnimTypeFollow()
    {
        curType = eUnitAiType.Follow;
    }

    protected override void OnSkillSelecte()
    {
        base.OnSkillSelecte();
        SetCurType(eUnitAiType.Follow);
        StartCoroutine(CoAiMovement());
    }

}





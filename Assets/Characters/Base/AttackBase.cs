using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackLight : MonoBehaviour
{
    public float Damage;
    public float HeavyDam;
    public float critChance;

    private float slidVal;

    public bool isCrit;
    public SpriteRenderer sR;
    private GameObject AttackSlide;
    private GameObject HitBox;
    private BaseDamageAttack BDA;
    private Animator anim;
    private BaseStats bs;
    private Movement mm;
    private Stamina Sta;

    public void Start()
    {
        bs = GameObject.FindGameObjectWithTag("Player").GetComponent<BaseStats>();
        Sta = GameObject.FindGameObjectWithTag("Player").GetComponent<Stamina>();
        mm = GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>();
        HitBox = gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;
        sR = gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>();
        BDA = HitBox.GetComponent<BaseDamageAttack>();
        anim = GetComponent<Animator>();
        AttackSlide = GameObject.FindGameObjectWithTag("AtkSlid");
        AttackSlide.SetActive(false);
    }

    public void Update()
    {

        float damAmount = bs.Power;
        
        if(critChance <= bs.Luck)
        {
            isCrit = true;
            damAmount = bs.Power * 4;
        }
        else if(critChance > bs.Luck)
        {
            isCrit = false;
            damAmount = bs.Power * 2;
        }

        Damage = damAmount;
        HeavyDam = damAmount * 1.5f;

        CharaDirection();

        if(!Sta.ChargeStamina)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                ChargeAttack();
            }
            if (Input.GetKeyUp(KeyCode.Mouse0))
            {

                if(isCrit)
                {
                    sR.color = Color.yellow;
                }
                else if(!isCrit)
                {
                    sR.color = Color.red;
                }

                ReleaseAttack();
            }
        }
        if(Sta.ChargeStamina)
        {
            AttackSlide.SetActive(false);
        }
    }

    public void CharaDirection()
    {
        if (mm.direction == 0)
        {
            transform.rotation = Quaternion.Euler(Vector3.zero);
        }
        if (mm.direction == 1)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 180));
        }
        if (mm.direction == 2)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90));
        }
        if (mm.direction == 3)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, -90));
        }
    }

    public void ChargeAttack()
    {

        critChance = Random.Range(1, 100);

        AttackSlide.SetActive(true);
        AttackSlide.GetComponent<Slider>().value = slidVal;
        slidVal += bs.Moxie * Time.deltaTime;

        if (slidVal >= 1)
        {
            slidVal = 1;
        }
    }

    public void ReleaseAttack()
    {

        if (slidVal < 1)
        {
            BDA.damage = Damage;
            anim.SetInteger("Attack", 1);
            StartCoroutine(TurnBack(0.20f));
        }
        else if (slidVal >= 1)
        {
            BDA.damage = HeavyDam;
            anim.SetInteger("Attack", 2);
            StartCoroutine(TurnBack(.5f));
        }

        StartCoroutine(StopAttackAnimation());
    }

    private IEnumerator StopAttackAnimation()
    {
        yield return new WaitForEndOfFrame();
        anim.SetInteger("Attack", 0);
        slidVal = 0;
        AttackSlide.SetActive(false);
        
    }


    private IEnumerator TurnBack(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        sR.color = Color.white;
    }
}
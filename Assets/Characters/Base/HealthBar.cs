using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    
    [Header("Health Stats")]
    public float HealthAmount;
    public float HealthMax;

    [Header("Mana Stats")]
    public float ManaAmount;
    public float ManaMax;

    [Header("Blockin")]
    public bool block;

    public GameObject hud;
    public GameObject DeathScene;

    private Slider HealthSlide;
    private Slider ManaSlide;
    private BaseStats bs;
    private Stamina Sta;
    private Movement mm;

    public void Start()
    {
        bs = gameObject.GetComponent<BaseStats>();
        HealthMax = bs.Health;
        ManaMax = bs.Mana;
        HealthSlide = GameObject.FindGameObjectWithTag("HPBar").GetComponent<Slider>();
        ManaSlide = GameObject.FindGameObjectWithTag("MPBar").GetComponent<Slider>();
        Sta = GetComponent<Stamina>();
        mm = GetComponent<Movement>();

    }

    public void Update()
    {
        
        HealthChange();
        ManaChange();

    }

    public void HealthChange()
    {

        float HRatio = HealthAmount / HealthMax;
        HealthSlide.value = HRatio;

        HealthAmount += bs.Vitality * Time.deltaTime;

        if(HealthAmount > HealthMax)
        {

            HealthAmount = HealthMax;

        }

        if(HealthAmount <= 0)
        {
            OnDeath();
        }
    }

    public void OnDeath()
    {
        hud.SetActive(false);
        DeathScene.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ManaChange()
    {

        float MRatio = ManaAmount / ManaMax;
        ManaSlide.value = MRatio;

        ManaAmount += bs.Spirit * Time.deltaTime;

        if(ManaAmount > ManaMax)
        {

            ManaAmount = ManaMax;

        }

    }

    public void TakeDam(float dam)
    {

        float damReduce = dam / 100 / 2 * bs.Endurance;
        float baseReduce = bs.Endurance * 2;
        float ReduceAmount = damReduce + baseReduce;
        float trueDam =  dam - ReduceAmount;
        float blockdam = trueDam / 2;

        if(block)
        {

            if(blockdam < 1)
            {
                blockdam = 1;
            }

            Sta.StaMin -= blockdam * 2;
            HealthAmount -= blockdam;

        }
        else if(!block)
        {

            if(trueDam < 2)
            {
                trueDam = 2;
            }

            HealthAmount -= trueDam;

        }

    }

    public void TakeMana(float Consume)
    {

        ManaAmount -= Consume;

    }

}
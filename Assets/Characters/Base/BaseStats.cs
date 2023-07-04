using UnityEngine;
using UnityEngine.UI;

public class BaseStats : MonoBehaviour
{
    [Header("Soul")]
    public float Health;    // determines how many health points chara can take
    public float Mana;      // determines how many mana points chara can take
    public float Stamina;   // determines stamina bar

    [Header("Mind")]
    public float Vitality;  // used to regain health
    public float Spirit;    // used to regain mana
    public float Moxie;     // used to regain stamina

    [Header("Body")]
    public int Power;       // determines strength of attacks and abilities
    public int Endurance;   // determines how many hits a character can take
    public int Agility;     // determines character speed
    public int Luck;        // determines critical chance

    [Header("Leveling")]
    public int Level;
    public float ExpNeeded;
    public float ExpAmount;

    public Slider ExpBar;
    public GameObject CharaLevel;
    public GameObject Ability1;
    public GameObject Ability2;
    public GameObject Ability3;
    public GameObject Ability4;
    public GameObject BaseLevel;

    public bool inGame;
    public bool Ability2B;
    public bool Ability3B;
    public bool Ability4B;

    public void Start()
    {
        GatherObject();
        TurnOffButtons();
    }

    public void FixedUpdate()
    {
        float ERatio = ExpAmount / ExpNeeded;
        
        if(ExpAmount >= ExpNeeded)
        {
            ERatio = 1;
        }

        ExpBar.value = ERatio;

        ExpNeeded = 100 * (Level * 0.05f) + (Level * 5 + 65);

        if (ExpAmount >= ExpNeeded)
        {
            OnLevelUp();
        }
    }

    public void GatherObject()
    {
        CharaLevel = GameObject.FindGameObjectWithTag("LevelChara").transform.gameObject;
        Ability1 = GameObject.FindGameObjectWithTag("LevelAbility1").transform.gameObject;
        Ability2 = GameObject.FindGameObjectWithTag("LevelAbility2").transform.gameObject;
        Ability3 = GameObject.FindGameObjectWithTag("LevelAbility3").transform.gameObject;
        Ability4 = GameObject.FindGameObjectWithTag("LevelAbility4").transform.gameObject;
        BaseLevel = GameObject.FindGameObjectWithTag("LevelUpStat").transform.gameObject;
        ExpBar = GameObject.FindGameObjectWithTag("ExpBar").transform.gameObject.GetComponent<Slider>();
    }

    public void OnLevelUp()
    {
        CharaLevel.SetActive(true);
        Ability1.SetActive(true);
        if (Ability2B)
        {
            Ability2.SetActive(true);
        }
        if (Ability3B)
        {
            Ability3.SetActive(true);
        }
        if (Ability4B)
        {
            Ability4.SetActive(true);
        }
        BaseLevel.SetActive(true);
    }

    public void TurnOffButtons()
    {
        CharaLevel.SetActive(false);
        Ability1.SetActive(false);
        Ability2.SetActive(false);
        Ability3.SetActive(false);
        Ability4.SetActive(false);
        BaseLevel.SetActive(false);
        Level += 1;
        ExpAmount -= ExpNeeded;
    }
}
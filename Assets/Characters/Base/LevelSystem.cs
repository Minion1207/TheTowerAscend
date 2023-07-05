using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSystem : MonoBehaviour
{

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

    public BaseStats bs;

    public void Start()
    {
        GatherObject();
        TurnOffButtons();
    }

    public void FixedUpdate()
    {
        float ERatio = ExpAmount / ExpNeeded;

        bs.Level = Level;

        if (ExpAmount >= ExpNeeded)
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
        bs = GameObject.FindGameObjectWithTag("Player").transform.gameObject.GetComponent<BaseStats>();
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

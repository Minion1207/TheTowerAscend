using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LevelBaseChara : MonoBehaviour
{
    public BaseStats stats;
    public float Increase;
    public TextMeshProUGUI tmpro;
    public int statIndex;
    public string statName;
    public GameObject Holder;
    public bool UpdateStat;
    public bool ChangeState;

    private void Start()
    {
        // Generate a random number to determine which stat will level up
        statIndex = Random.Range(0, 11);

        statName = "";

        switch (statIndex)
        {
            case 0:
                statName = "Health";
                Increase = 5;
                break;
            case 1:
                statName = "Mana";
                Increase = 5;
                break;
            case 2:
                statName = "Stamina";
                Increase = 5;
                break;
            case 3:
                statName = "Vitality";
                Increase = 0.05f;
                break;
            case 4:
                statName = "Spirit";
                Increase = 0.05f;
                break;
            case 5:
                statName = "Moxie";
                Increase = 0.05f;
                break;
            case 6:
                statName = "Power";
                Increase = 1;
                break;
            case 7:
                statName = "Endurance";
                Increase = 1;
                break;
            case 8:
                statName = "Agility";
                Increase = 0.25f;
                break;
            case 9:
                statName = "Luck";
                Increase = 1;
                break;
            case 10:
                statName = "SoulFragments";
                Increase = 1;
                break;
            case 11:
                statName = "Gold";
                Increase = 10;
                break;
            default:
                Debug.LogError("Invalid stat index!");
                break;
        }

        tmpro.text = statName + " + " + Increase.ToString();

    }

    private void Update()
    {
        if(UpdateStat)
        {
            LevelUp();
        }

        if (ChangeState)
        {
            if (!string.IsNullOrEmpty(statName))
            {
                LevelUpStat(statName);
            }
        }
    }

    public void Change()
    {
        ChangeState = true;
    }

    public void UpdateStatBlock()
    {
        UpdateStat = true;
    }

    private void LevelUp()
    {
        // Generate a random number to determine which stat will level up
        statIndex = Random.Range(0, 11);

        statName = "";

        switch (statIndex)
        {
            case 0:
                statName = "Health";
                Increase = 5;
                break;
            case 1:
                statName = "Mana";
                Increase = 5;
                break;
            case 2:
                statName = "Stamina";
                Increase = 5;
                break;
            case 3:
                statName = "Vitality";
                Increase = 0.05f;
                break;
            case 4:
                statName = "Spirit";
                Increase = 0.05f;
                break;
            case 5:
                statName = "Moxie";
                Increase = 0.05f;
                break;
            case 6:
                statName = "Power";
                Increase = 1;
                break;
            case 7:
                statName = "Endurance";
                Increase = 1;
                break;
            case 8:
                statName = "Agility";
                Increase = 0.25f;
                break;
            case 9:
                statName = "Luck";
                Increase = 1;
                break;
            case 10:
                statName = "SoulFragments";
                Increase = 1;
                break;
            case 11:
                statName = "Gold";
                Increase = 10;
                break;
            default:
                Debug.LogError("Invalid stat index!");
                break;
        }

        tmpro.text = statName + " + " + Increase.ToString();

    }

    public void LevelUpStat(string statName)
    {
        if (string.IsNullOrEmpty(statName))
        {
            Debug.LogError("Invalid stat name: " + statName);
            return;
        }

        var field = stats.GetType().GetField(statName);
        if (field != null)

        {
            var fieldType = field.FieldType;

            if (fieldType == typeof(int))
            {
                int currentValue = (int)field.GetValue(stats);
                field.SetValue(stats, currentValue + (int)Increase);
            }
            else if (fieldType == typeof(float))
            {
                float currentValue = (float)field.GetValue(stats);
                field.SetValue(stats, currentValue + Increase);
            }
            else
            {
                Debug.LogError("Invalid field type for stat: " + statName);
            }

            // Display the level up information
            tmpro.text = statName + " + " + Increase.ToString();
        }
        else
        {
            Debug.LogError("Invalid stat name: " + statName);
        }

        ChangeState = false;
        UpdateStat = false;
        Holder.SetActive(false);

    }
}
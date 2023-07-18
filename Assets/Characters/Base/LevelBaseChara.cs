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
        LevelUp();
    }

    private void Update()
    {
        if (UpdateStat)
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
        statIndex = Random.Range(0, 12);

        statName = "";

        switch (statIndex)
        {
            case 0:
                if (stats.Health < 10000)
                {
                    statName = "Health";
                    Increase = 5;
                }
                else
                {
                    statName = "SoulFragments";
                    Increase = 1;
                }
                break;

            case 1:
                if (stats.Mana < 10000)
                {
                    statName = "Mana";
                    Increase = 5;
                }
                else
                {
                    statName = "SoulFragments";
                    Increase = 1;
                }
                break;

            case 2:
                if (stats.Stamina < 1000)
                {
                    statName = "Stamina";
                    Increase = 5;
                }
                else
                {
                    statName = "SoulFragments";
                    Increase = 1;
                }
                break;

            case 3:
                if (stats.Vitality < 10)
                {
                    statName = "Vitality";
                    Increase = 0.05f;
                }
                else
                {
                    statName = "Gold";
                    Increase = 10;
                }
                break;

            case 4:
                if (stats.Spirit < 10)
                {
                    statName = "Spirit";
                    Increase = 0.05f;
                }
                else
                {
                    statName = "Gold";
                    Increase = 10;
                }
                break;

            case 5:
                if (stats.Moxie < 10)
                {
                    statName = "Moxie";
                    Increase = 0.05f;
                }
                else
                {
                    statName = "Gold";
                    Increase = 10;
                }
                break;

            case 6:
                if (stats.Power < 99)
                {
                    statName = "Power";
                    Increase = 1;
                }
                else
                {
                    statName = "Gold";
                    Increase = 10;
                }
                break;

            case 7:
                if (stats.Endurance < 99)
                {
                    statName = "Endurance";
                    Increase = 1;
                }
                else
                {
                    statName = "SoulFragments";
                    Increase = 1;
                }
                break;

            case 8:
                if (stats.Agility < 99)
                {
                    statName = "Agility";
                    Increase = 0.25f;
                }
                else
                {
                    statName = "Gold";
                    Increase = 10;
                }
                break;

            case 9:
                if (stats.Luck < 99)
                {
                    statName = "Luck";
                    Increase = 1;
                }
                else
                {
                    statName = "SoulFragments";
                    Increase = 1;
                }
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
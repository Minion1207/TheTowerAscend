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
    public float Gold;
    public float SoulFragments;
}
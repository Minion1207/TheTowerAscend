using UnityEngine;

public class BaseStats : MonoBehaviour
{
    
    [Header("Soul")]
    public float Health;    //determines how many health points chara can take
    public float Mana;      //determines how many mana points chara can take
    public float Stamina;   //Detemins stamina bar

    [Header("Mind")]
    public float Vitality;  //Used to regain health
    public float Spirit;    //Used to Regain Mana
    public float Moxie;     //Used to regain Stamina

    [Header("Body")]
    public int Power;       //Detimens strength of attacks and abilities
    public int Endurance;   //Determines how much hits a character can take
    public int Agility;     //Determins Character Speed
    public int Luck;        //Determines Crit Chance

}
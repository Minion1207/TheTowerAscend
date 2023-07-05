using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public GameObject Shield;
    public HealthBar HB;
    public Stamina Sta;

    public void Start()
    {
        Shield = gameObject.transform.GetChild(0).gameObject;
        HB = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthBar>();
        Sta = GameObject.FindGameObjectWithTag("Player").GetComponent<Stamina>();
    }

    void Update()
    {
        if(!Sta.ChargeStamina)
        {
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                if (Sta.StaMin > 1.5f)
                {
                    HB.block = true;
                    Shield.SetActive(true);
                }
            }
            if(Input.GetKeyUp(KeyCode.Mouse1))
            {
                HB.block = false;
                Shield.SetActive(false);
            }
        }
        else if(Sta.ChargeStamina)
        {
            HB.block = false;
            Shield.SetActive(false);
        }

    }
}
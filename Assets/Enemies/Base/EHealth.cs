using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EHealth : MonoBehaviour
{
    public float Health = 1;
    public float EHealthMax = 10;
    public float Defense = 5;
    public float ExpAmount;
    public GameObject SoulFragment;
    public TextMeshProUGUI damAmount;
    public GameObject textObject;

    public void Start()
    {
        textObject = transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;
        damAmount = textObject.GetComponent<TextMeshProUGUI>();
        Health = EHealthMax;
        textObject.SetActive(false);
    }

    public void Update()
    {
        if(Health >= EHealthMax)
        {
            Health = EHealthMax;
        }
        if(Health <= 0)
        {
            DeathAmount();
        }
    }

    public void TakeDam(float dam)
    {
        float damReduce = Defense / 100 / 2 * Defense;
        float baseReduce = Defense * 2;
        float reduceAmount = damReduce + baseReduce;
        float trueDam =  dam - reduceAmount;

        Debug.Log(damReduce.ToString());
        Debug.Log(baseReduce.ToString());
        Debug.Log(reduceAmount.ToString());
        Debug.Log(trueDam.ToString());

        if(trueDam <= 3)
        {
            trueDam = 3;
        }

        textObject.SetActive(true);
        damAmount.text = trueDam.ToString();

        Health -= trueDam;

        StartCoroutine(TakeDamage());
    }

    public IEnumerator TakeDamage()
    {
        yield return new WaitForSeconds(1.0f);
        textObject.SetActive(false);
    }

    public void DeathAmount()
    {
        Instantiate(SoulFragment, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }

}

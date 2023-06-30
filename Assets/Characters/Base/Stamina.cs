using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Stamina : MonoBehaviour
{
    [Header("Stamina Values")]
    public float StaMin;
    public float StaMax;
    public float StaCharge;
    public bool ChargeStamina;

    private Slider StaSlider;
    private BaseStats bs;
    private Block block;
    private Movement mm;

    public void Start()
    {
        GatherResources();
    }

    public void Update()
    {

        StaBarSet();

        if (StaMin <= 0)
        {
            StaMin = 0;
            ChargeStamina = true;
            StaminaEmpty();
        }

        if(ChargeStamina)
        {
            StaMin += bs.Moxie * 5 * Time.deltaTime;
        }

        if (StaMin >= StaMax)
        {
            mm.enabled = true;
            block.enabled = true;
            ChargeStamina = false;
        }

    }

    public void GatherResources()
    {
        bs = GetComponent<BaseStats>();
        mm = GetComponent<Movement>();
        block = GameObject.FindGameObjectWithTag("Block").GetComponent<Block>();
        StaSlider = GameObject.FindGameObjectWithTag("StaBar").GetComponent<Slider>();
        StaMax = bs.Stamina;
        StaMin = StaMax;
        StaCharge = bs.Moxie;
    }

    public void StaBarSet()
    {
        float Ratio = StaMin / StaMax;
        StaSlider.value = Ratio;

        StaMin += StaCharge * Time.deltaTime;

        if (StaMin >= StaMax)
        {
            StaMin = StaMax;
        }
    }

    public void StaminaEmpty()
    {

        mm.enabled = false;
        GetComponent<Rigidbody2D>().velocity = Vector3.zero;

    }
}
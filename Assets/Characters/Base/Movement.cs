using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour


{
    public float normalSpeed = 5f;
    public float boostSpeed = 25f;
    public float boostDuration = 0.25f;
    public float dashCost = 5;
    public bool dashing = false;
    

    public float currentSpeed;
    public int direction;

    public Vector2 desiredVelocity;
    private Animator anim;
    private Rigidbody2D rb;
    private Stamina sta;
    private BaseStats bs;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb==null)
        {print ("rbisnull"); }
        sta = GetComponent<Stamina>();
        bs = GetComponent<BaseStats>();
        anim = gameObject.transform.GetChild(0).gameObject.GetComponent<Animator>();
        currentSpeed = normalSpeed;


    }

    private void Update()
    {
        normalSpeed = bs.Agility;

        if (Input.GetKeyDown(KeyCode.Space) && sta.StaMin >= dashCost)
        {
            dashing = true;
            sta.StaMin -= dashCost;
            StartCoroutine(BoostSpeed());
        }

        if (!dashing)
        {
            currentSpeed = normalSpeed;
        }
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        if(moveHorizontal == 0 && moveVertical == 0)
        {
            anim.SetBool("IsRunning", false);
        }
        else
        {
            anim.SetBool("IsRunning", true);
        }

        ChooseDirection();

        desiredVelocity = new Vector2(moveHorizontal, moveVertical);
        Vector2 clampedVelocity = Vector2.ClampMagnitude(desiredVelocity * currentSpeed, currentSpeed);

        rb.velocity = clampedVelocity;

    }

    private void ChooseDirection()
    {
        // 0 = down, 1 = up, 2 = right, 3 = left
        if (desiredVelocity.y < 0)
        {
            anim.SetInteger("Direction", 0);
            direction = 0;
        }
        else if (desiredVelocity.y > 0)
        {
            anim.SetInteger("Direction", 1);
            direction = 1;
        }
        else if (desiredVelocity.x > 0)
        {
            anim.SetInteger("Direction", 2);
            direction = 2;
        }
        else if (desiredVelocity.x < 0)
        {
            anim.SetInteger("Direction", 3);
            direction = 3;
        }
        else if (desiredVelocity.y > 0 && desiredVelocity.x > 0)
        {
            anim.SetInteger("Direction", 1);
            direction = 1;
        }
        else if (desiredVelocity.y > 0 && desiredVelocity.x < 0)
        {
            anim.SetInteger("Direction", 1);
            direction = 1;        
        }
        else if (desiredVelocity.y < 0 && desiredVelocity.x > 0)
        {
            anim.SetInteger("Direction", 0);
            direction = 0;
        }
        else if (desiredVelocity.y < 0 && desiredVelocity.x < 0)
        {
            anim.SetInteger("Direction", 0);
            direction = 0;
        }

    }

    private IEnumerator BoostSpeed()
    {
        currentSpeed = boostSpeed;
        yield return new WaitForSeconds(boostDuration);
        dashing = false;
        currentSpeed = normalSpeed;
    }


        Rigidbody m_Rigidbody;


}
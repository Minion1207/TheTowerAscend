using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EProjectile : MonoBehaviour
{
    public float damage;
    public float Speed;
    public float LifeTime;
    public Vector3 direction;
    public bool shootTowardsPlayer;
    public bool followPlayer;

    private float angle;

    private Transform playerTransform;
    private Vector3 playerDirection;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        playerDirection = (playerTransform.position - transform.position).normalized;
        angle = Mathf.Atan2(playerDirection.y, playerDirection.x) * Mathf.Rad2Deg + 90;
    }

    void Update()
    {

        if (shootTowardsPlayer)
        {            
            transform.position += playerDirection * Speed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(Vector3.forward * angle);
        }
        else if (followPlayer)
        {
            Vector3 playerDirection = (playerTransform.position - transform.position).normalized;
            transform.position += playerDirection * Speed * Time.deltaTime;
            transform.rotation = Quaternion.LookRotation(Vector3.forward, -playerDirection);
        }
        else
        {
            transform.position += direction * Speed * Time.deltaTime;
        }

        LifeTime -= Time.deltaTime;
        if (LifeTime < 0)
        {
            Destroy(gameObject);
        }


    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "CharaIcon")
        {
            GameObject.FindGameObjectWithTag("Player").SendMessage("TakeDam", damage * 3);
            Destroy(gameObject);
        }
    }
}
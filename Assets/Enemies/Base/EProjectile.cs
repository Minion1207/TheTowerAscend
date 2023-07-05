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

    private Transform playerTransform;
    private Vector3 playerDirection;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        playerDirection = (playerTransform.position - transform.position).normalized;
    }

    void Update()
    {
        if (shootTowardsPlayer)
        {            
            transform.position += playerDirection * Speed * Time.deltaTime;
        }
        else if (followPlayer)
        {
            transform.position += (playerTransform.position - transform.position).normalized * Speed * Time.deltaTime;
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
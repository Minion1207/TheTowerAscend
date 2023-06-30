using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EProjectile : MonoBehaviour
{
    
    public float damage;
    public float Speed;

    void Update()
    {
        transform.position += Vector3.down * Speed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            col.SendMessage("TakeDam", damage * 3);
            Destroy(gameObject);
        }
    }

}

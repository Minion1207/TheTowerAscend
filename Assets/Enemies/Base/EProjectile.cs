using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EProjectile : MonoBehaviour
{
    
    public float damage;
    public float Speed;
    public float LifeTime;

    void Update()
    {
        transform.position += Vector3.down * Speed * Time.deltaTime;
        LifeTime -= 1 * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "CharaIcon")
        {
            GameObject.FindGameObjectWithTag("Player").transform.gameObject.SendMessage("TakeDam", damage * 3);
            Destroy(gameObject);
        }
    }

}

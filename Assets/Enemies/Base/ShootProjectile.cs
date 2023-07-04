using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootProjectile : MonoBehaviour
{
    public float dam;
    public float ProjectileSpeed;
    public float ProjectileLife;
    public float Timer;
    public GameObject Arrow;
    public Transform SpawnPoint;

    private float TimeAmount;

    void Start()
    {
        TimeAmount = Timer;
    }

    void Update()
    {
        TimeAmount -= Time.deltaTime;

        if (TimeAmount <= 0)
        {
            TimeAmount = Timer;
            GameObject obj = Instantiate(Arrow, SpawnPoint.position, Quaternion.identity);

            EProjectile projectile = obj.GetComponent<EProjectile>();
            if (projectile != null)
            {
                projectile.damage = dam;
                projectile.Speed = ProjectileSpeed;
                projectile.LifeTime = ProjectileLife;
            }
        }
    }
}
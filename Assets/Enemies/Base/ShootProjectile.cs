using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootProjectile : MonoBehaviour
{
    public float dam;
    public float ProjectileSpeed;
    public float ProjectileLife;
    public float Timer;
    public int Direction;
    public bool Shoot;
    public bool Track;
    public bool Follow;
    public bool Melee;
    public GameObject Arrow;
    public Transform SpawnPoint;
    public float ShootingDistance;
    public Transform player; // Reference to the player's transform

    private float TimeAmount;

    void Start()
    {
        TimeAmount = Timer;
        player = GameObject.FindGameObjectWithTag("Player").gameObject.transform;
    }

    void Update()
    {
        // Calculate the distance between the enemy and the player
        float distance = Vector3.Distance(transform.position, player.position);

        // Check if the player is within the shooting distance
        if (distance <= ShootingDistance)
        {
            Shoot = true; // Enable shooting
        }
        else
        {
            Shoot = false; // Disable shooting
        }

        if (Shoot)
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

                    projectile.shootTowardsPlayer = Track;
                    projectile.followPlayer = Follow;
                    projectile.Melee = Melee;

                    if (Direction == 0)
                    {
                        projectile.direction = Vector3.down;
                        obj.transform.rotation = Quaternion.Euler(Vector3.zero);
                    }
                    else if (Direction == 1)
                    {
                        projectile.direction = Vector3.up;
                        obj.transform.rotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, 180.0f));
                    }
                    else if (Direction == 2)
                    {
                        projectile.direction = Vector3.right;
                        obj.transform.rotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, 90.0f));
                    }
                    else if (Direction == 3)
                    {
                        projectile.direction = Vector3.left;
                        obj.transform.rotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, -90.0f));
                    }
                }
            }
        }
        else if (!Shoot)
        {
            TimeAmount = Timer;
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EMovement : MonoBehaviour
{
    public GameObject player;
    public float normalSpeed;
    public float avoidanceSpeedMultiplier;
    public float distanceBetween;
    public float avoidForce;
    public float avoidDistance;
    public LayerMask obstacleMask; // Layer mask for obstacles

    private float distance;
    private bool isAvoiding = false;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        obstacleMask = LayerMask.GetMask("obstacleMask");
    }

    private void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();

        if (distance < distanceBetween)
        {
            // Check for obstacles
            Collider2D obstacle = Physics2D.OverlapCircle(transform.position, avoidDistance, obstacleMask);

            if (obstacle != null)
            {
                // Calculate avoidance force
                Vector2 avoidanceForce = CalculateAvoidanceForce(obstacle.transform.position, obstacle.bounds.size);

                // Apply avoidance force
                transform.position += (Vector3)avoidanceForce * GetSpeed() * Time.deltaTime;
                isAvoiding = true;
            }
            else
            {
                // No obstacle in the way, move towards the player
                transform.position = Vector2.MoveTowards(transform.position, player.transform.position, GetSpeed() * Time.deltaTime);
                isAvoiding = false;
            }
        }
    }

    private float GetSpeed()
    {
        if (isAvoiding)
        {
            return normalSpeed * avoidanceSpeedMultiplier;
        }
        else
        {
            return normalSpeed;
        }
    }

    private Vector2 CalculateAvoidanceForce(Vector2 obstaclePosition, Vector2 obstacleSize)
    {
        // Calculate the vector from the obstacle position to the enemy
        Vector2 obstacleToEnemy = (Vector2)transform.position - obstaclePosition;

        // Normalize the obstacleToEnemy vector
        obstacleToEnemy.Normalize();

        // Calculate the avoidance force
        Vector2 avoidanceForce = obstacleToEnemy * avoidForce;

        // Adjust the force based on the size of the obstacle
        float sizeScaleFactor = obstacleSize.magnitude / 2f;
        avoidanceForce *= sizeScaleFactor;

        return avoidanceForce;
    }

    private void OnDrawGizmosSelected()
    {
        // Visualize obstacle avoidance radius
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, avoidDistance);
    }
}
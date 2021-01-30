using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyVision : MonoBehaviour
{
    public float visionRadius;
    public float distanceObstacleCheck;
    public float speed = 10;
    public LayerMask groundLayer;
    public LayerMask playerLayer;

    private EnemyMovement enemyMovement;
    private Transform player;
    
    private Vector2[] directions = {
        new Vector2(0,1),
        new Vector2(1, 1), 
        new Vector2(1,0),
        new Vector2(-1, 1), 
        new Vector2(0,-1),
        new Vector2(-1, -1), 
        new Vector2(-1,0),
        new Vector2(-1, 1), 
    };

    private bool[] directionsCheck = {false, false, false, false, false, false, false, false};

    private bool isObstacleAhead;
    private bool isPlayerDetected;
    
    
    private void Awake()
    {
        enemyMovement = GetComponent<EnemyMovement>();
    }

    private void Update()
    {
        if (!isObstacleAhead)
        {
            Debug.Log("Looking player");
            var other = Physics2D.OverlapCircle(transform.position, visionRadius, playerLayer);
            if (other != null)
            {
                isPlayerDetected = true;
                player = other.transform;
                enemyMovement.PlayerDetect(true);
                enemyMovement.FollowToPlayer(other.transform.position);
            }
            else
            {
                enemyMovement.PlayerDetect(false);
                isPlayerDetected = false;
            }
        }
        if (isPlayerDetected)
        {
            //CheckAround();
        }
        
    }
    
    private void CheckAround()
    {
        var index = 0;
        foreach (var direction in directions)
        {
            index += 1;
            if (index == directions.Length) index = 0;
            if (GenerateRay(direction))
            {
                Debug.Log("Obstacle");
                directionsCheck[index] = true;
                isObstacleAhead = true;
                if (direction.x == 0 && direction.y > 0)
                {
                    Debug.Log("right");
                    enemyMovement.FollowToPlayer(direction * -1 + (Vector2)transform.position * speed);
                }
            }
            else
            {
                directionsCheck[index] = false;
            }
        }

        var tmp = false;
        foreach (var check in directionsCheck)
        {
            if (check)
            {
                tmp = true;
            }
        }
        
        isObstacleAhead = tmp;
        
        Debug.Log($"obstacle {isObstacleAhead}");
    }
    
    private bool GenerateRay(Vector2 direction)
    {
        return Physics2D.Raycast(transform.position, direction, distanceObstacleCheck, groundLayer);
    }
    
    private Vector2 CalculateVectorToMove()
    {
        return player.position - transform.position;
    }
}

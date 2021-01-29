using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObstacleCheck : MonoBehaviour
{
    public float distanceCheck;
    public LayerMask layerCheck;
    
    
    private Vector2[] directions = {
        new Vector2(0,1),
        new Vector2(0,-1),
        new Vector2(1,0),
        new Vector2(-1,0)
    };

    private EnemyMovement movement;
    
    private Vector2 testPlayerPosition = new Vector2(20, 20);
    private Vector2 testEnemyPosition = new Vector2( 10 , 30);

    private bool isPlayerDetected;

    private void Awake()
    {
        movement = GetComponent<EnemyMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isPlayerDetected)
            CheckAround();
    }

    private void CheckAround()
    {
        foreach (var direction in directions)
        {
            if (GenerateRay(direction))
            {
                Debug.Log("Obstacle");
                movement.FollowToPlayer(CalculateVectorToMove(direction * 100));
            }
        }
    }


    private bool GenerateRay(Vector2 direction)
    {
        return Physics2D.Raycast(transform.position, direction, distanceCheck, layerCheck);
    }

    private Vector2 CalculateVectorToMove(Vector2 direction)
    {
        var distance = movement.GetPlayerPosition().position - transform.position;
        var tmp = distance * direction;
        distance.x -= tmp.x;
        distance.y -= tmp.y;
        return distance;
    }

    public void DetectPlayer(bool isDetected)
    {
        isPlayerDetected = isDetected;
    }
}

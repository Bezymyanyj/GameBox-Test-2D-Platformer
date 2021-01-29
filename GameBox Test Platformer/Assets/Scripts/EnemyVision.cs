using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVision : MonoBehaviour
{
    public float visionRadius;
    public LayerMask layer;

    private CircleCollider2D circleCollider;
    private EnemyMovement enemyMovement;
    private EnemyObstacleCheck enemyObstacleCheck;
    private void Awake()
    {
        enemyObstacleCheck = GetComponent<EnemyObstacleCheck>();
        //circleCollider = GetComponent<CircleCollider2D>();
        enemyMovement = GetComponent<EnemyMovement>();
    }

    private void Start()
    {
        //circleCollider.radius = visionRadius;
    }

    private void Update()
    {
        var other = Physics2D.OverlapCircle(transform.position, visionRadius, layer);
        if (other != null)
        {
            enemyMovement.PlayerDetected(other.transform);
            enemyMovement.FollowToPlayer(other.transform.position);
            enemyObstacleCheck.DetectPlayer(true);
        }
        
    }


    // private void OnTriggerEnter2D(Collider2D other)
    // {
    //     if (!other.CompareTag("Player")) return;
    //     enemyMovement.PlayerDetected(other.transform);
    //     enemyObstacleCheck.DetectPlayer(true);
    //     //Debug.Log("I see you");
    // }
    //
    // private void OnTriggerExit2D(Collider2D other)
    // {
    //     if (!other.CompareTag("Player")) return;
    //     enemyMovement.PlayerRunAway();
    //     enemyObstacleCheck.DetectPlayer(false);
    //     //Debug.Log("Bye Bye");
    // }
}

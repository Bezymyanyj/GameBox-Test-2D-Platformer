using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVision : MonoBehaviour
{
    public float visionRadius;

    private CircleCollider2D circleCollider;
    private EnemyMovement enemyMovement;
    private void Awake()
    {
        circleCollider = GetComponent<CircleCollider2D>();
        enemyMovement = GetComponent<EnemyMovement>();
    }

    private void Start()
    {
        circleCollider.radius = visionRadius;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        enemyMovement.PlayerDetected(other.transform);
        Debug.Log("I see you");
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        enemyMovement.PlayerRunAway();
        Debug.Log("Bye Bye");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform target;
    public float speed;

    private Vector2 startPosition;

    private bool isPlayerDetected;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(isPlayerDetected) return;
        var distance = Vector2.Distance(transform.position, target.position);
        if (distance < 0.1f)
        {
            Flip();
            var tmp = target.position;
            target.position = startPosition;
            startPosition = tmp;
        }
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }

    public void FollowToPlayer(Vector2 player)
    {
        transform.position = Vector2.MoveTowards(transform.position, player, speed * Time.deltaTime);
        //Debug.Log(player);
    }
    
    private void Flip()
    {
        
        var scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    public void PlayerDetect(bool playerDetected)
    {
        isPlayerDetected = playerDetected;
    }
}

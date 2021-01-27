using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform target;

    public float speed;

    private Vector2 startPosition;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        var distance = Vector2.Distance(transform.position, target.position);
        if (distance < 0.1f)
        {
            var tmp = target.position;
            target.position = startPosition;
            startPosition = tmp;
        }
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        
    }
}

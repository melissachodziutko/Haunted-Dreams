using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    public float speed;
    public int direction = 1;

    public float chasingTime;
    public float visionLength;
    public Transform player;
    public Transform spawnPoint;

    private bool isChasing = false;
    private bool goingRight = true;
    private float chaseTimer;
    private bool outsideBounds = false;

    // Update is called once per frame
    void Update()
    {
        if (!isChasing)
        {
            if (!outsideBounds)
            {
                Patrol();
                Sight();
            }
            else
                ReturnToSpawn();
        }
        else
            Chase();

    }

    void Patrol()
    {
        if (goingRight)
            direction = 1;
        else
            direction = -1;


        Vector2 move = Vector2.right * direction;

        transform.Translate(move * speed * Time.deltaTime);
    }

    void Sight()
    {
        RaycastHit2D hitR = Physics2D.Raycast(transform.position, Vector2.right, visionLength);
        RaycastHit2D hitL = Physics2D.Raycast(transform.position, Vector2.left, visionLength);
        Debug.DrawRay(transform.position, Vector2.right, Color.red);
        Debug.DrawRay(transform.position, Vector2.left, Color.red);

        if (!isChasing && hitR.collider != null && hitL.collider != null)
        {
            if (hitR.collider.CompareTag("Player") || hitL.collider.CompareTag("Player"))
            {
                Debug.Log("hit the player");
                PlayerMovement.pages -= 1;
                isChasing = true;
            }

            if (hitR.collider.CompareTag("Boundary") || hitL.collider.CompareTag("Boundary"))
            {
                Debug.Log("hit a boundary");
                if (goingRight)
                    goingRight = false;
                else
                    goingRight = true;
            }
        }


    }

    void Chase()
    {
        //Debug.Log("chasing");
        chaseTimer -= Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

        if (chaseTimer <= 0)
        {
            isChasing = false;
            chaseTimer = chasingTime;
        }
    }

    void ReturnToSpawn()
    {
        Debug.Log("returning");
        transform.position = Vector2.MoveTowards(transform.position, spawnPoint.position, speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Boundary"))
        {
            Debug.Log("outside");
            outsideBounds = true;
        }

        if (collision.CompareTag("Spawn"))
        {
            outsideBounds = false;
        }
    }
}

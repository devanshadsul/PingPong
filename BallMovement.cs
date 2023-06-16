using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public gameManager game;
    public float moveSpeed;
    private float maxStaytime =5f;
    private float timer = 0f;
    //private bool isMoving = true;
    //private Vector2 autoMove = Vector2.right;
    private Rigidbody2D rb;
    private Vector3 startPosition;
    private float speedInc = 1f;
    private float ballTimer = 0f;
    private Vector2 currentVel;
    private float slowBall = 0f;
    

    void Start()
    {
        startPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
        moveSpeed = 6f;
        Launch();

    }

    
    void Update()
    {
        if(rb.velocity.y == 0f)
        {
            timer = timer + Time.deltaTime;

                if(timer >= maxStaytime)
                {
                    if(transform.position.y <= 0)
                    {
                        rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y + 1.5f);
                        timer = 0f;
                    }
                    else
                    {
                        rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y - 1.5f);
                        timer = 0f;
                    }
                            
                }
                        
        }

        ballTimer = ballTimer + Time.deltaTime;
        if(ballTimer > 10f)
        {
            currentVel = rb.velocity;
            if(currentVel.x < 0 && currentVel.y<0)
            {
                rb.velocity = new Vector2(currentVel.x - speedInc, currentVel.y - speedInc);
                ballTimer = 0f;
            }
            else if(currentVel.x > 0 && currentVel.y > 0)
            {
                rb.velocity = new Vector2(currentVel.x + speedInc, currentVel.y + speedInc);
                ballTimer = 0f;
            }
            else if(currentVel.x < 0 && currentVel.y > 0)
            {
                rb.velocity = new Vector2(currentVel.x - speedInc, currentVel.y + speedInc);
                ballTimer = 0f;
            }
            else
            {
                rb.velocity = new Vector2(currentVel.x + speedInc, currentVel.y - speedInc);
                ballTimer = 0f;
            }
            
        }

        // if(rb.velocity.x < 4f || rb.velocity.x > -4f)
        // {
        //     slowBall = slowBall + Time.deltaTime;
        //     if(slowBall <= 2f)
        //     {
        //         currentVel = rb.velocity;
        //         rb.velocity = new Vector2(currentVel.x + speedInc, currentVel.y + speedInc);
        //     }
        // }
                
                
    }

    void OnTriggerEnter2D(Collider2D collide)
    {
        if(collide.CompareTag("redWall"))
        {
            game.player2Scores();
            StartCoroutine(ResetPos(2f));
            moveSpeed = 6f;
            ballTimer = 0f;

        }

        if(collide.CompareTag("blueWall"))
        {
            game.player1Scores();
            StartCoroutine(ResetPos(2f));
            moveSpeed = 6f;
            ballTimer = 0f;
            
        }
    }

    private IEnumerator ResetPos(float delay)
    {
        yield return new WaitForSeconds(delay);

        transform.position = startPosition;
        rb.velocity = new Vector2(6f, 6f);
    }

    private void Launch()
    {
        float x = Random.Range(0,2) == 0 ? - 1 : 1;
        float y = Random.Range(0,2) == 0 ? - 1 : 1;
        rb.velocity = new Vector2(moveSpeed * x, moveSpeed * y);
    }

    
}

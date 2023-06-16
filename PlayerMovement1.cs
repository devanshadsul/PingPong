using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement1 : MonoBehaviour
{
    
    public float moveSpeed;
    //private float move;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    
    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.UpArrow))
        {
           rb.velocity = new Vector2(0,moveSpeed);
            if(transform.position.y > 4f)
            {
                rb.velocity = Vector2.zero;
            }
        }

        else if(Input.GetKey(KeyCode.DownArrow))
        {
            rb.velocity = new Vector2(0,-moveSpeed);
            if(transform.position.y < -4f)
            {
                rb.velocity = Vector2.zero;
            }
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }
}

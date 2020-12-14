using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{    
    public bool IsLeathal { get; set; }
    public float Speed { get; set; }    
    public bool FaceLeft { get; set; }

    private void Update()
    {
        ResetPos();
        Movement();
    }

    public void ResetPos()
    {
        var x = 9;
        if (FaceLeft)
        {
            if (transform.position.x < -x)
            {
                transform.position = new Vector2(x, transform.position.y);
            }
        }
        else
        {
            if (transform.position.x > x)
            {
                transform.position = new Vector2(-x, transform.position.y);
            }
        }
    }

    public void Movement()
    {
        if (FaceLeft) transform.Translate(Vector2.right * -Speed * Time.deltaTime);
        if (!FaceLeft) transform.Translate(Vector2.right * Speed * Time.deltaTime);

        if (GetComponent<SpriteRenderer>())
        {
            GetComponent<SpriteRenderer>().flipX = FaceLeft;
        }
        else
        {
            foreach (Transform child in transform)
            {
                child.GetComponent<SpriteRenderer>().flipX = FaceLeft;
            }
        }
    }
}

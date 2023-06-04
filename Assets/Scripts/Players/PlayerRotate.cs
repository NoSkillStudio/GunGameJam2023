using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotate : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool isFasingRight = true;
    private void Start()
    {
        rb = GetComponentInParent<Rigidbody2D>();
    }

    private void Update()
    {
        if ((rb.velocity.x > 0 && !isFasingRight) || (rb.velocity.x < 0 && isFasingRight)) 
        {
            Turn();
        }
    }

    private void Turn()
    {
        isFasingRight = !isFasingRight;

        //Vector3 scale = transform.localScale;
        //scale.x *= -1;
        //transform.localScale = scale;
        transform.Rotate(0, 180, 0);
    }
}
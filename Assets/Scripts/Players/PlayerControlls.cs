using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlls : MonoBehaviour
{
    public float Speed = 2;
    private Rigidbody2D rigidbody2d;
    private bool isFasingRight = true;

    [SerializeField] private KeyCode left;
    [SerializeField] private KeyCode right;
    [SerializeField] private KeyCode up;
    [SerializeField] private KeyCode down;

    private void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        rigidbody2d.velocity = Vector2.zero;
        if (Input.GetKey(left)) rigidbody2d.velocity += Vector2.left * Speed;
        if (Input.GetKey(right)) rigidbody2d.velocity += Vector2.right * Speed;
        if (Input.GetKey(up)) rigidbody2d.velocity += Vector2.up * Speed;
        if (Input.GetKey(down)) rigidbody2d.velocity += Vector2.down * Speed;

        if (rigidbody2d.velocity.x > 0 && !isFasingRight)
        {
            Turn();
        }
        else if (rigidbody2d.velocity.x < 0 && isFasingRight)
        {
            Turn();
        }
    }

    private void Turn()
    {
        isFasingRight = !isFasingRight;

        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

}
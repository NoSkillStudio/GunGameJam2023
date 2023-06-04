using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlls : MonoBehaviour
{
    public float Speed = 2;
    private Rigidbody2D rb;


    [SerializeField] private KeyCode left;
    [SerializeField] private KeyCode right;
    [SerializeField] private KeyCode up;
    [SerializeField] private KeyCode down;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        rb.velocity = Vector2.zero;
        if (Input.GetKey(left)) rb.velocity += Vector2.left * Speed;
        if (Input.GetKey(right)) rb.velocity += Vector2.right * Speed;
        if (Input.GetKey(up)) rb.velocity += Vector2.up * Speed;
        if (Input.GetKey(down)) rb.velocity += Vector2.down * Speed;


    }

    public void InverseControlls()
    {
        KeyCode a = left;
        KeyCode b = right;
        KeyCode c = up;
        KeyCode d = down;

        left = b;
        right = a;
        up = d;
        down = c;

        Invoke(nameof(ReturnNormalControlls), 5f);
    }

    public void ReturnNormalControlls()
    {
        KeyCode a = left;
        KeyCode b = right;
        KeyCode c = up;
        KeyCode d = down;

        left = b;
        right = a;
        up = d;
        down = c;
    }

    public void SetPosition(Transform transform) => this.transform.position = transform.position;
}

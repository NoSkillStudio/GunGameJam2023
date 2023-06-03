using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlls : MonoBehaviour
{
    public float Speed = 2;
    private Rigidbody2D componentRigidbody;
    private bool isFasingRight = true;
    private Camera camera;
    [SerializeField] private MultipleTargetCamera targetCamera;

    [SerializeField] private KeyCode left;
    [SerializeField] private KeyCode right;
    [SerializeField] private KeyCode up;
    [SerializeField] private KeyCode down;

    private void Start()
    {
        componentRigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        componentRigidbody.velocity = Vector2.zero;
        if (Input.GetKey(left)) componentRigidbody.velocity += Vector2.left * Speed;
        if (Input.GetKey(right)) componentRigidbody.velocity += Vector2.right * Speed;
        if (Input.GetKey(up)) componentRigidbody.velocity += Vector2.up * Speed;
        if (Input.GetKey(down)) componentRigidbody.velocity += Vector2.down * Speed;

        if (Input.GetKey(right) && !isFasingRight)
        {
            Turn();
        }
        else if (Input.GetKey(left) && isFasingRight)
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

    //private void CheckBoundaries()
    //{ 
    //if(transform.position.x > targetCamera.GetBoundsSize().x)
    //}
}
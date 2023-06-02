using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_1_Controls : MonoBehaviour
{
    public float Speed = 2;
    private Rigidbody2D componentRigidbody;
    private bool isFasingRight = true;
    private Camera camera;
    [SerializeField] private MultipleTargetCamera targetCamera;

    private void Start()
    {
        componentRigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        componentRigidbody.velocity = Vector2.zero;
        if (Input.GetKey(KeyCode.A)) componentRigidbody.velocity += Vector2.left * Speed;
        if (Input.GetKey(KeyCode.D)) componentRigidbody.velocity += Vector2.right * Speed;
        if (Input.GetKey(KeyCode.W)) componentRigidbody.velocity += Vector2.up * Speed;
        if (Input.GetKey(KeyCode.S)) componentRigidbody.velocity += Vector2.down * Speed;

        if (Input.GetKey(KeyCode.D) && !isFasingRight)
        {
            Turn();
        }
        else if (Input.GetKey(KeyCode.A) && isFasingRight)
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
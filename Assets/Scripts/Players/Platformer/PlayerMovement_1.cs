using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement_1 : MonoBehaviour
{
    [SerializeField] private CharacterController2D controller;
    [SerializeField] private KeyCode jumpKey;
    float horizontalMove = 0f;
    public float runSpeed = 40f;
    private bool jump = false;
    // bool crouch = false;

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("WASDHorizontal") * runSpeed;

        if (Input.GetKeyDown(jumpKey))
        {
            jump = true;
        }
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, jump);
        jump = false;
    }
}

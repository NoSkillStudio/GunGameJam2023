using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement_1 : MonoBehaviour
{
    [SerializeField] private CharacterController2D contoller;

    float horizontalMove = 0f;

    public float runSpeed = 40f;
    bool jump = false;
    bool crouch = false;

    [SerializeField] private KeyCode jumpKey;

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("WASDHorizontal") * runSpeed;

        //if (Input.GetKey(left)) horizontalMove = -runSpeed;
        //if (Input.GetKey(right)) horizontalMove = runSpeed;
        //else horizontalMove = 0;


        if (Input.GetKeyDown(jumpKey))
        {
            jump = true;
        }


    }

    void FixedUpdate()
    {
        contoller.Move(horizontalMove * Time.fixedDeltaTime, jump);
        jump = false;
    }
}
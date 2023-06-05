using UnityEngine;

public class PlayerMovement_2 : MonoBehaviour
{
    [SerializeField] private CharacterController2D controller;
    [SerializeField] private KeyCode jumpKey;
    public float runSpeed = 40f;
    private float horizontalMove = 0f;
    private bool jump = false;
    // private bool crouch = false;


    void Update()
    {
        horizontalMove = Input.GetAxisRaw("ArrowHorizontal") * runSpeed;

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

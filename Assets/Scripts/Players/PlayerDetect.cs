using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerDetect : MonoBehaviour
{
    [SerializeField] private float rayDistance = 3f;
    [SerializeField] private GameObject detectedPlayerFront;
    [SerializeField] private GameObject detectedPlayerBack;
    [SerializeField] private Transform castPoint;
    private bool isFacingRight = true;
    private Rigidbody2D rb;
    private float castDistance;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        castDistance = rayDistance;
        if (GetIsFacingRight() == false) castDistance = -rayDistance;

        Collider2D hit = Physics2D.OverlapBox(
            castPoint.position,
            new Vector2(rayDistance, 0.2f),
            0
        );

        if (hit.gameObject == detectedPlayerBack)
        {
            Debug.Log(detectedPlayerFront.name + " is found!");
        }
        if (hit.gameObject == detectedPlayerFront)
        {
            Debug.Log("drawn game");
        }
        

    }

    private void OnDrawGizmosSelected()
    {
        if (castPoint == null)
            return;
        Gizmos.DrawCube(castPoint.position, new Vector2(rayDistance, 0.2f));
    }

    private bool GetIsFacingRight()
    {
        if (rb.velocity.x > 0)
            isFacingRight = true;
        else if ((rb.velocity.x < 0))
            isFacingRight = false;
       // Debug.Log(isFacingRight);
        return isFacingRight;
    }
}

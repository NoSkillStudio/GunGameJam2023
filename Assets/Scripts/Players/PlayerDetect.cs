using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerDetect : MonoBehaviour
{
    [SerializeField] private float rayDistance = 3f;
    [SerializeField] private GameObject detectedPlayerFront;
    [SerializeField] private GameObject detectedPlayerBack;
    [SerializeField] private Transform castPoint;
    private bool isFacingRight = true;
    private Rigidbody2D rigidbody2D;

    private float castDistance;
    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        castDistance = rayDistance;
        if (GetIsFacingRight() == false) castDistance = -rayDistance;

        //Vector2 endPos = castPoint.position + Vector3.right * castDistance;

        //Debug.DrawLine(castPoint.position, endPos, Color.green);
        //RaycastHit2D hit = Physics2D.Raycast(castPoint.position, transform.right, castDistance);

        //if (hit.collider != null)
        //{
        //    if (hit.collider.gameObject == detectedPlayerBack)
        //    {
        //        Debug.Log(detectedPlayerFront.name + " is found!");
        //        Debug.DrawLine(castPoint.position, endPos, Color.yellow);
        //    }
        //    if (hit.collider.gameObject == detectedPlayerFront)
        //    {
        //        Debug.Log("drawn game");
        //        Debug.DrawLine(castPoint.position, endPos, Color.yellow);
        //    }
        //}




        Collider2D hit = Physics2D.OverlapBox(castPoint.position, new Vector2(rayDistance, 0.2f), 0);
        
        
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
        if (rigidbody2D.velocity.x > 0)
            isFacingRight = true;
        else if ((rigidbody2D.velocity.x < 0))
            isFacingRight = false;
       // Debug.Log(isFacingRight);
        return isFacingRight;
    }
}
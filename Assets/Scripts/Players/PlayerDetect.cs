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
        if (rb.velocity.x > 0)
            isFacingRight = true;
        else if ((rb.velocity.x < 0))
            isFacingRight = false;

        castDistance = rayDistance;
        if (!isFacingRight) castDistance = -rayDistance;

        Collider2D hit = Physics2D.OverlapBox(
            castPoint.position,
            new Vector2(rayDistance, 0.2f),
            0
        );

        try // без try catch ошибка NullReferenceException
        {
            if (hit.gameObject == detectedPlayerBack)
            {
                Debug.Log(detectedPlayerFront.name + " is found!");
            }
            if (hit.gameObject == detectedPlayerFront)
            {
                Debug.Log("drawn game");
            }
            }
        catch { }
    }

    private void OnDrawGizmosSelected()
    {
        if (castPoint == null)
            return;

        Gizmos.DrawCube(castPoint.position, new Vector2(rayDistance, 0.2f));
    }
}

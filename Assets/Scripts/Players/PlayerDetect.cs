using UnityEngine;
using UnityEngine.Events;

public class PlayerDetect : MonoBehaviour
{
    [SerializeField] private float rayDistance = 3f;

    [SerializeField] private GameObject detectedPlayer;
    [SerializeField] private GameObject tilemap;
    [SerializeField] private Transform castPoint;
    public bool isFacingRight = true;
    private Rigidbody2D rb;
    private float castDistance;

    [SerializeField] private UnityEvent OnWin;
    [SerializeField] private UnityEvent OnDraw;

    [SerializeField] private LayerMask layerMask;

    private bool canDetect = true;
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

        Collider2D hit;

        if (canDetect)
        {
            hit = Physics2D.OverlapBox(castPoint.position, new Vector2(rayDistance, 0.2f), 0, layerMask);



            if (hit != null)
            {
                //Debug.Log(hit.gameObject.name);

                if (hit.gameObject == detectedPlayer)
                {
                    canDetect = false;
                    if (isFacingRight && detectedPlayer.GetComponent<PlayerDetect>().isFacingRight) OnWin.Invoke();
                    if (isFacingRight == false && detectedPlayer.GetComponent<PlayerDetect>().isFacingRight == false) OnWin.Invoke();

                    if (isFacingRight && detectedPlayer.GetComponent<PlayerDetect>().isFacingRight == false) OnDraw.Invoke();
                    if (isFacingRight == false && detectedPlayer.GetComponent<PlayerDetect>().isFacingRight) OnDraw.Invoke();
                }

                else if (hit.gameObject == tilemap.gameObject) return;
            }

        }



    }

    private void OnDrawGizmosSelected()
    {
        if (castPoint == null)
            return;

        Gizmos.DrawCube(castPoint.position, new Vector2(rayDistance, 0.2f));
    }
}

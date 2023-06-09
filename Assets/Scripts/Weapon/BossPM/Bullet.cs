using UnityEngine;

public class Bullet : MonoBehaviour
{
	[SerializeField] protected float speed;
	[SerializeField] protected Rigidbody2D rb;

    public int Damage;

    private void FixedUpdate()
    {
        rb.velocity = transform.right * speed;
    }

    private void Update()
    {
       // CheckBoundaries();
    }
    private void CheckBoundaries()
    {
        Vector2 screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        if (transform.position.x < -screenBounds.x || transform.position.x > screenBounds.x || transform.position.y < -screenBounds.y || transform.position.y > screenBounds.y)
        {
            //Deactivate();
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out IDamageable damageable))
        {
            damageable.ApplyDamage(Damage);
            //Deactivate();
        }
            Destroy(gameObject);
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
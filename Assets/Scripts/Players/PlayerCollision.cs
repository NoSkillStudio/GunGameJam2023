using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private AudioSource eatSound;
    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {

    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out PressurePlate player))
        {
            eatSound.Play();
        }

    }
}
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;

public class PressurePlate : MonoBehaviour
{
    [SerializeField] private UnityEvent OnPressedByPlayer_1;
    [SerializeField] private UnityEvent OnPressedByPlayer_2;
    [SerializeField] private float offset;
    [SerializeField] private float pressTime;
    private new Collider2D collider2D;

    private void Start()
    {
        collider2D = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.TryGetComponent(out IPLayer_1 pLayer_1))
        { 
            OnPressedByPlayer_1?.Invoke();
            Destroy(gameObject);
        }

        if (collision.gameObject.TryGetComponent(out IPlayer_2 pLayer_2))
        {
            OnPressedByPlayer_2?.Invoke();
            Destroy(gameObject);
        }
    }
}

using UnityEngine;
using UnityEngine.Events;

public class PressurePlate : MonoBehaviour
{
    [SerializeField] private UnityEvent OnPressedByPlayer_1;
    [SerializeField] private UnityEvent OnPressedByPlayer_2;

    

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.TryGetComponent(out IPLayer_1 pLayer_1))
        {           
            FindObjectOfType<EventsRandomaizer_1>().ActiveRandomEvent();
            FindObjectOfType<PillSpawner>().Spawn();
            Destroy(gameObject);
        }

        else if (collision.gameObject.TryGetComponent(out IPlayer_2 pLayer_2))
        {
            FindObjectOfType<EventsRandomaizer_2>().ActiveRandomEvent();
            FindObjectOfType<PillSpawner>().Spawn();
            Destroy(gameObject);
        }
    }
}

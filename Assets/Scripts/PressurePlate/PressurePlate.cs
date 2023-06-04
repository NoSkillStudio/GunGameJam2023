using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;

public class PressurePlate : MonoBehaviour
{
    [SerializeField] private UnityEvent OnPressedByPlayer_1;
    [SerializeField] private UnityEvent OnPressedByPlayer_2;
    [SerializeField] private float offset;
    [SerializeField] private float pressTime;
    private Collider2D collider2D;

    private void Start()
    {
        collider2D = GetComponent<Collider2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out IPlayer player))
        {
            transform.DOMoveY(transform.position.y - offset, pressTime);
        }

        if (collision.gameObject.TryGetComponent(out IPLayer_1 pLayer_1))
        { 
            OnPressedByPlayer_1.Invoke();
            Debug.Log("OnPressedByPlayer_1");    
        }

        if (collision.gameObject.TryGetComponent(out IPlayer_2 pLayer_2))
        {
            OnPressedByPlayer_2.Invoke();
            Debug.Log("OnPressedByPlayer_2");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out IPlayer player))
        {
            collider2D.enabled = false;
            transform.DOMoveY(transform.position.y + offset, pressTime);
        }
    }
}

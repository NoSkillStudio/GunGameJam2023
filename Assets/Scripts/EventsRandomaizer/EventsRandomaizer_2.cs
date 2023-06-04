using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventsRandomaizer_2 : MonoBehaviour
{
    [SerializeField] private UnityEvent[] events;
    private UnityEvent currentEvent;
    int index;

    public void ActiveRandomEvent() => GetRandomEvent().Invoke();

    private UnityEvent GetRandomEvent()
    {
        index = Random.Range(0, events.Length);
        currentEvent = events[index];
        return currentEvent;
    }
}
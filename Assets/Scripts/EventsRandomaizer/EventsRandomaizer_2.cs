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
        //index = 8;
        currentEvent = events[index];
        Debug.Log(index);
        return currentEvent;
    }
}
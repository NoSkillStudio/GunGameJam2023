using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class MultipleTargetCamera : MonoBehaviour
{
    [SerializeField] private List<Transform> targets;

    [SerializeField] private Vector3 offset;
    [SerializeField] private float smoothTime = 0.5f;

    [SerializeField] private float minZoom = 40f;
    [SerializeField] private float maxZoom = 10f;
    [SerializeField] private float zoomLimiter = 50f;

    private Vector3 velocity;
    private Camera camera;

    private void Start()
    {
        camera = GetComponent<Camera>();
    }
    private void LateUpdate()
    {
        if(targets.Count == 0)
            return; 
        Move();
        //Zoom();
    }

    //private void Zoom()
    //{
    //    float newZoom = Mathf.Lerp(minZoom, maxZoom, GetGreatestDistance() / zoomLimiter);
    //    camera.fieldOfView = Mathf.Lerp(camera.fieldOfView, newZoom, Time.deltaTime);
    //}

    private void Move()
    {
        Vector3 centerPoint = GetCenterPoint();

        Vector3 newPosition = centerPoint + offset;

        transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, smoothTime);
    }

    //private float GetGreatestDistance()
    //{
    //    var bounds = new Bounds(targets[0].position, Vector3.zero);

    //    for (int i = 0; i < targets.Count; i++)
    //    {
    //        bounds.Encapsulate(targets[i].position);
    //    }

    //    return bounds.size.x;
    //}

    public Vector3 GetBoundsSize()
    {
        var bounds = new Bounds(targets[0].position, Vector3.zero);

        for (int i = 0; i < targets.Count; i++)
        {
            bounds.Encapsulate(targets[i].position);
        }

        return bounds.size;
    }

    private Vector3 GetCenterPoint()
    {
        if (targets.Count == 1)
        { 
            return targets[0].position;
        }

        var bounds = new Bounds(targets[0].position, Vector3.zero);

        for (int i = 0; i < targets.Count; i++)
        {
            bounds.Encapsulate(targets[i].position);
        }

        return bounds.center;
    }
}
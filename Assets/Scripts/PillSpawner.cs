using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillSpawner : MonoBehaviour
{
    [SerializeField] private GameObject pillPrefab;
    [SerializeField] private Transform[] points;

    private void Start()
    {
        Spawn();
    }
    public void Spawn()
    {

        for (int i = 0; i < GetRandomCountOfPills(); i++)
        {
            Instantiate(pillPrefab, GetRandomTransform().position, Quaternion.identity);
        }
    }

    private Transform GetRandomTransform()
    {
        int index;
        index = Random.Range(0, points.Length);
        return points[index];
    }

    private int GetRandomCountOfPills()
    {
        return Random.Range(1, 5);
    }
}
using UnityEngine;

public class FinishSpawner : MonoBehaviour
{
    [SerializeField] private GameObject finish_prefab;
    [SerializeField] private Transform[] points;
    [SerializeField] private float minDistance;
    private Transform player1;
    private Transform player2;

    private void Start()
    {
        player1 = FindObjectOfType<Player_1_Collision>().transform;
        player2 = FindObjectOfType<Player_2_Collision>().transform;
    }

    public void Spawn()
    {
        Vector2 p1 = player1.position;
        Vector2 p2 = player2.position;
        Vector2 pos;
        do
        {
            pos = GetRandomTransform().position;
        } while(
            Vector2.Distance(pos, p1) < minDistance
            || Vector2.Distance(pos, p2) < minDistance
        );
        Instantiate(finish_prefab, pos, Quaternion.identity);
    }

    private Transform GetRandomTransform()
    {
        int index;
        index = Random.Range(0, points.Length);
        return points[index];

    }
}

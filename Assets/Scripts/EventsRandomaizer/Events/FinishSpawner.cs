using UnityEngine;

public class FinishSpawner : MonoBehaviour
{
    [SerializeField] private GameObject finish_prefab;
    [SerializeField] private Vector2 a;
    [SerializeField] private Vector2 b;

    #if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(a, 0.25f);
        Gizmos.DrawSphere(b, 0.25f);
    }
    #endif

    public void Spawn()
    {
        Vector2 pos = new Vector2(Random.Range(a.x, b.x), Random.Range(a.y, b.y));
        Instantiate(finish_prefab, Vector3.zero, Quaternion.identity);
    }
}

using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerTilePainter : MonoBehaviour
{
    [SerializeField] private Tile paintTile;
    [SerializeField] private Tilemap tilemap;

    [ContextMenu("Paint")]

    public void Paint(Vector3 position)
    {
        tilemap.SetTile(Vector3Int.FloorToInt(position), paintTile);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 9)
        {
            Debug.Log("1");
            Paint(collision.gameObject.GetComponent<Transform>().position);
            Debug.Log(collision.gameObject.GetComponent<Transform>().position);
           

        }
    }
}
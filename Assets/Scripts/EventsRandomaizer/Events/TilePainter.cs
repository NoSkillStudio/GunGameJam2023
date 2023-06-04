using UnityEngine;
using UnityEngine.Tilemaps;

public class TilePainter : MonoBehaviour
{
	[SerializeField] private Tile paintTile;
	[SerializeField] private Tilemap tilemap;

	[ContextMenu("Paint")]

	public void Paint(Vector3 position)
	{ 
	
	}
}
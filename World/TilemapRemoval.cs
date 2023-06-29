using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapRemoval : MonoBehaviour
{
    public Transform playerTransform;
    public Tilemap tilemap;
    public float distanceThreshold = 10f;

    private void Update()
    {
        Vector3 playerPosition = playerTransform.position;

        BoundsInt bounds = tilemap.cellBounds;
        TileBase[] allTiles = tilemap.GetTilesBlock(bounds);

        foreach (var position in bounds.allPositionsWithin)
        {
            Vector3Int tilePosition = new Vector3Int(position.x, position.y, position.z);
            Vector3 tileWorldPosition = tilemap.CellToWorld(tilePosition);

            float distance = Vector3.Distance(playerPosition, tileWorldPosition);

            if (distance > distanceThreshold)
            {
                tilemap.SetTile(tilePosition, null);
            }
        }
    }
}

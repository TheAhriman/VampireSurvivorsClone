using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapGenerator : MonoBehaviour
{
    public Tilemap tilemap;
    public Tile[] tilePrefabs;
    public Transform player;
    private void Update()
    {
        GenerateTilemap();
    }
    private void GenerateTilemap()
    {
        for (int x = -10 + Mathf.RoundToInt(player.position.x); x <= 10 + Mathf.RoundToInt(player.position.x); x++)
        {
            for (int y = -10 + Mathf.RoundToInt(player.position.y); y <= 10 + Mathf.RoundToInt(player.position.y); y++)
            {
                // Выбираем случайный префаб и текстуру
                Tile tilePrefab = tilePrefabs[Random.Range(0, tilePrefabs.Length)];
                // Добавляем блок в tilemap
                if (!tilemap.HasTile(new Vector3Int(x, y, 0))){
                    tilemap.SetTile(new Vector3Int(x, y, 0), tilePrefab);
                }
            }
        }
    }
}

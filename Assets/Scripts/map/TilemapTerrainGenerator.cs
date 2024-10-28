using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapTerrainGenerator : MonoBehaviour
{
    public Tilemap tilemap;
    public Tile groundTile;
    public int width = 100;
    public int maxHeight = 10;
    public float scale = 10f;

    void Start()
    {
        GenerateTerrain();
    }

    void GenerateTerrain()
    {
        for (int x = 0; x < width; x++)
        {
            // ʹ�� PerlinNoise ���� y �߶�
            float y = Mathf.PerlinNoise(x / scale, 0) * maxHeight;
            int terrainHeight = Mathf.RoundToInt(y);

            for (int i = 0; i < terrainHeight; i++)
            {
                // ���� Tile �� Tilemap
                Vector3Int position = new Vector3Int(x, i, 0);
                tilemap.SetTile(position, groundTile);
            }
        }
    }
}

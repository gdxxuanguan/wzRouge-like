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
            // 使用 PerlinNoise 生成 y 高度
            float y = Mathf.PerlinNoise(x / scale, 0) * maxHeight;
            int terrainHeight = Mathf.RoundToInt(y);

            for (int i = 0; i < terrainHeight; i++)
            {
                // 设置 Tile 到 Tilemap
                Vector3Int position = new Vector3Int(x, i, 0);
                tilemap.SetTile(position, groundTile);
            }
        }
    }
}

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class roomWalkerGenerator : MonoBehaviour
{
    public Tilemap tilemap;             // 用于显示瓦片的 Tilemap
    public TileBase floorTile;          // 地板瓦片
    public TileBase wallTile;           // 墙壁瓦片

    public int width;              // 地牢宽度
    public int height;             // 地牢高度
    public int roomCount;          // 房间数量
    public int minRoomSize;         // 最小房间尺寸
    public int maxRoomSize;        // 最大房间尺寸

    private List<RectInt> rooms;        // 房间的矩形列表
    private System.Random random;

    void Start()
    {
        random = new System.Random();
        rooms = new List<RectInt>();
        GenerateDungeon();
    }

    void GenerateDungeon()
    {
        // 清空当前 Tilemap
        tilemap.ClearAllTiles();

        //生成起始房间
        RectInt initRoom = new RectInt(-2, -2, 6, 6);
        CreateRoom(initRoom);
        rooms.Add(initRoom);

        // 1. 生成房间
        for (int i = 0; i < roomCount; i++)
        {
            int roomWidth = random.Next(minRoomSize, maxRoomSize);
            int roomHeight = random.Next(minRoomSize, maxRoomSize);
            int x = random.Next(1, width - roomWidth - 1);
            int y = random.Next(1, height - roomHeight - 1);
            var newRoom = new RectInt(x, y, roomWidth, roomHeight);

            // 检查房间是否与现有房间重叠
            bool overlaps = false;
            foreach (var room in rooms)
            {
                if (newRoom.Overlaps(room))
                {
                    overlaps = true;
                    break;
                }
            }

            // 如果不重叠，添加到房间列表，并生成地板
            if (!overlaps)
            {
                rooms.Add(newRoom);
                CreateRoom(newRoom);
            }
        }

        // 2. 连接房间
        for (int i = 0; i < rooms.Count - 1; i++)
        {
            var roomA = rooms[i].center;
            var roomB = rooms[i + 1].center;

            // 随机选择先连接水平或垂直方向
            if (random.Next(2) == 0)
            {
                CreateHorizontalCorridor((int)roomA.x, (int)roomB.x, (int)roomA.y);
                CreateVerticalCorridor((int)roomA.y, (int)roomB.y, (int)roomB.x);
            }
            else
            {
                CreateVerticalCorridor((int)roomA.y, (int)roomB.y, (int)roomA.x);
                CreateHorizontalCorridor((int)roomA.x, (int)roomB.x, (int)roomB.y);
            }
        }

        // 3. 创建墙壁
        //CreateWalls();
    }

    void CreateRoom(RectInt room)
    {
        for (int x = room.xMin; x < room.xMax; x++)
        {
            for (int y = room.yMin; y < room.yMax; y++)
            {
                tilemap.SetTile(new Vector3Int(x, y, 0), floorTile);
            }
        }
    }

    void CreateHorizontalCorridor(int xStart, int xEnd, int y)
    {
        for (int x = Mathf.Min(xStart, xEnd); x <= Mathf.Max(xStart, xEnd)+1; x++)
        {
            tilemap.SetTile(new Vector3Int(x, y, 0), floorTile);
            tilemap.SetTile(new Vector3Int(x, y-1, 0), floorTile);
            tilemap.SetTile(new Vector3Int(x, y+1, 0), floorTile);
        }
    }

    void CreateVerticalCorridor(int yStart, int yEnd, int x)
    {
        for (int y = Mathf.Min(yStart, yEnd); y <= Mathf.Max(yStart, yEnd)+1; y++)
        {
            tilemap.SetTile(new Vector3Int(x, y, 0), floorTile);
            tilemap.SetTile(new Vector3Int(x+1, y, 0), floorTile);
            tilemap.SetTile(new Vector3Int(x-1, y, 0), floorTile);
        }
    }

    void CreateWalls()
    {
        // 遍历地牢的每一个地板瓦片，检查其四周是否需要生成墙壁
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Vector3Int tilePos = new Vector3Int(x, y, 0);
                if (tilemap.GetTile(tilePos) == floorTile)
                {
                    // 检查周围的8个方向，如果没有地板瓦片则放置墙壁瓦片
                    PlaceWallIfEmpty(x + 1, y);
                    PlaceWallIfEmpty(x - 1, y);
                    PlaceWallIfEmpty(x, y + 1);
                    PlaceWallIfEmpty(x, y - 1);
                    PlaceWallIfEmpty(x + 1, y + 1);
                    PlaceWallIfEmpty(x - 1, y + 1);
                    PlaceWallIfEmpty(x + 1, y - 1);
                    PlaceWallIfEmpty(x - 1, y - 1);
                }
            }
        }
    }

    void PlaceWallIfEmpty(int x, int y)
    {
        Vector3Int pos = new Vector3Int(x, y, 0);
        if (tilemap.GetTile(pos) == null)
        {
            tilemap.SetTile(pos, wallTile);
        }
    }
}

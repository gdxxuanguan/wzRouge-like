using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class roomWalkerGenerator : MonoBehaviour
{
    public Tilemap tilemap;             // ������ʾ��Ƭ�� Tilemap
    public TileBase floorTile;          // �ذ���Ƭ
    public TileBase wallTile;           // ǽ����Ƭ

    public int width;              // ���ο��
    public int height;             // ���θ߶�
    public int roomCount;          // ��������
    public int minRoomSize;         // ��С����ߴ�
    public int maxRoomSize;        // ��󷿼�ߴ�

    private List<RectInt> rooms;        // ����ľ����б�
    private System.Random random;

    void Start()
    {
        random = new System.Random();
        rooms = new List<RectInt>();
        GenerateDungeon();
    }

    void GenerateDungeon()
    {
        // ��յ�ǰ Tilemap
        tilemap.ClearAllTiles();

        //������ʼ����
        RectInt initRoom = new RectInt(-2, -2, 6, 6);
        CreateRoom(initRoom);
        rooms.Add(initRoom);

        // 1. ���ɷ���
        for (int i = 0; i < roomCount; i++)
        {
            int roomWidth = random.Next(minRoomSize, maxRoomSize);
            int roomHeight = random.Next(minRoomSize, maxRoomSize);
            int x = random.Next(1, width - roomWidth - 1);
            int y = random.Next(1, height - roomHeight - 1);
            var newRoom = new RectInt(x, y, roomWidth, roomHeight);

            // ��鷿���Ƿ������з����ص�
            bool overlaps = false;
            foreach (var room in rooms)
            {
                if (newRoom.Overlaps(room))
                {
                    overlaps = true;
                    break;
                }
            }

            // ������ص�����ӵ������б������ɵذ�
            if (!overlaps)
            {
                rooms.Add(newRoom);
                CreateRoom(newRoom);
            }
        }

        // 2. ���ӷ���
        for (int i = 0; i < rooms.Count - 1; i++)
        {
            var roomA = rooms[i].center;
            var roomB = rooms[i + 1].center;

            // ���ѡ��������ˮƽ��ֱ����
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

        // 3. ����ǽ��
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
        // �������ε�ÿһ���ذ���Ƭ������������Ƿ���Ҫ����ǽ��
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Vector3Int tilePos = new Vector3Int(x, y, 0);
                if (tilemap.GetTile(tilePos) == floorTile)
                {
                    // �����Χ��8���������û�еذ���Ƭ�����ǽ����Ƭ
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

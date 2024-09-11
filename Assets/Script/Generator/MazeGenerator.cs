using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGenerator : MonoBehaviour
{
    public int width = 5;
    public int height = 5;

    public Wall wallPrefab;
    private Wall[,] wallMap;
    void Start()
    {
        BatchWalls();
        MakeMaze(wallMap[0,0]);
    }

    private void BatchWalls()
    {
        wallMap = new Wall[width, height];
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Wall wall = Instantiate<Wall>(wallPrefab, this.transform);
                wall.index = new Vector2Int(x, y);
                wall.name = "wall" + x + y;
                wall.transform.localPosition = new Vector3(x * 2, 0, y * 2);

                wallMap[x, y] = wall;
            }
        }
    }

    private void MakeMaze(Wall startWall)
    {
        Wall[] neighbors = GetNeighborWalls(startWall);
        if(neighbors.Length > 0)
        {
            Wall nextWall = neighbors[Random.Range(0, neighbors.Length)];
            ConnectWalls(startWall, nextWall);
        }
    }

    private Wall[] GetNeighborWalls(Wall wall)
    {
        List<Wall> returnWallList = new List<Wall>();
        Vector2Int index = wall.index;
        if(index.y +1 < height)
        {
            Wall neighbor = wallMap[index.x, index.y + 1];
            if (neighbor.CheckAllWall())
            {
                returnWallList.Add(neighbor);
            }
        }
        if (index.y - 1 >= 0)
        {
            Wall neighbor = wallMap[index.x, index.y - 1];
            if (neighbor.CheckAllWall())
            {
                returnWallList.Add(neighbor);
            }
        }
        if (index.x+1 < width)
        {
            Wall neighbor = wallMap[index.x + 1, index.y];
            if (neighbor.CheckAllWall())
            {
                returnWallList.Add(neighbor);
            }
        }
        if (index.x -1 >= 0)
        {
            Wall neighbor = wallMap[index.x - 1, index.y];
            if (neighbor.CheckAllWall())
            {
                returnWallList.Add(neighbor);
            }
        }
        return returnWallList.ToArray();
    }

    private void ConnectWalls(Wall wall0, Wall wall1)
    {
        Vector2Int dir = wall0.index - wall1.index;
        if(dir.y <= -1)
        {
            wall0.isFrontWall = false;
            wall1.isBackWall = false;
        }
        if (dir.y >= 1)
        {
            wall0.isBackWall = false;
            wall1.isFrontWall = false;
        }
        if (dir.x <= -1)
        {
            wall0.isRightWall = false;
            wall1.isLeftWall = false;
        }
        if (dir.x >= 1)
        {
            wall0.isLeftWall = false;
            wall1.isRightWall = false;
        }
        wall0.SetWall();
        wall1.SetWall();
    }
}

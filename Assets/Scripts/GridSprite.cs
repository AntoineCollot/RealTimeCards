using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSprite : MonoBehaviour {

    public int xSize;
    public int ySize;

    public float tileSize;

    public Transform tile;

    [ContextMenu("Create grid")]
    public void CreateGrid()
    {
        for (int x = 0; x < xSize; x++)
        {
            for (int y = 0; y < ySize; y++)
            {
                Instantiate(tile, new Vector2(x * tileSize, y * tileSize), Quaternion.identity, transform);
            }
        }
    }
}

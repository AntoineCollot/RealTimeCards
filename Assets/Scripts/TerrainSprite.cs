using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainSprite : MonoBehaviour {

    public PlayArea area;

    public Transform wallTile;

    public Transform cornerTile;

    [ContextMenu("Create Terrain")]
    public void CreateTerrain()
    {
        Transform wallHolder = new GameObject("Walls").transform;
        wallHolder.parent = transform;

        Transform floorHolder = new GameObject("Floor").transform;
        floorHolder.parent = transform;

        //Walls
        Vector3 position = Vector2.up * ((area.height / 2) + 0.5f);
        for (int x = 0; x < area.width; x++)
        {

            position.x = x+1 - area.width / 2 - 0.5f;
            Instantiate(wallTile, position, Quaternion.identity, wallHolder);
        }
        position.y = -((area.height / 2) + 0.5f);
        for (int x = 0; x < area.width; x++)
        {
            position.x = x+1 - area.width / 2 - 0.5f;
            Instantiate(wallTile, position, Quaternion.identity, wallHolder);
        }
        position.x = ((area.width / 2) + 0.5f);
        for (int y = 0; y < area.height; y++)
        {
            position.y = y+1 - area.height / 2 - 0.5f;
            Instantiate(wallTile, position, Quaternion.Euler(0, 0, -90), wallHolder);
        }

        position.x = -((area.width / 2) + 0.5f);
        for (int y = 0; y < area.height; y++)
        {
            position.y = y+1 - area.height / 2 - 0.5f;
            Instantiate(wallTile, position, Quaternion.Euler(0, 0, 90), wallHolder);
        }

        //Corners
        Instantiate(cornerTile, new Vector2(((area.width / 2) + 0.5f), ((area.height / 2) + 0.5f)), Quaternion.Euler(0, 0, -90), wallHolder);
        Instantiate(cornerTile, new Vector2(-((area.width / 2) + 0.5f), ((area.height / 2) + 0.5f)), Quaternion.Euler(0,0,0), wallHolder);
        Instantiate(cornerTile, new Vector2(((area.width / 2) + 0.5f), -((area.height / 2) + 0.5f)), Quaternion.Euler(0, 0, 180), wallHolder);
        Instantiate(cornerTile, new Vector2(-((area.width / 2) + 0.5f), -((area.height / 2) + 0.5f)), Quaternion.Euler(0, 0,90), wallHolder);
    }
}

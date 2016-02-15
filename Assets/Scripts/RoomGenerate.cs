﻿using UnityEngine;
using System.Collections;

public class RoomGenerate  {
    public GameObject basicTile;
    public GameObject plane;
	int[,] roomPosition;   
	int[,] roomMaxtrix;
	//0 = left
	//1 = top
	//2= right
	//3= bottom
	int[] connectionsToRooms;
    // Use this for initialization
   	 RoomGenerate(int[,]position, int[]connections)
	{
		roomMaxtrix =new int[10, 10];
		roomPosition = position;
		connectionsToRooms = connections;
	}
    public void Generate()
    {
        Instantiate(plane, new Vector3(0, 0, 0), Quaternion.identity);
        int xArray = roomMaxtrix.GetLength(0);
        int yArray = roomMaxtrix.GetLength(1);

        for (int i = 0; i < xArray; i++)
        {
            for (int m = 0; m < yArray; m++)
            {
                // instantate a new tile as child with a unique name
                GameObject tile = (GameObject)Instantiate(basicTile, new Vector3(i, m, 0), Quaternion.identity);
                tile.transform.parent = GameObject.Find("Plane(Clone)").transform;
                // 0,0 is bottome left hand corner.
                tile.name = "Tile Column:" + i + "Row:" + m;
            }
        }

    }
}
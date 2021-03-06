﻿using UnityEngine;
using System.Collections;

public class RoomGenerate:MonoBehaviour  {
    
    public GameObject basicTile;
    public GameObject tDoor;
    public GameObject lDoor;
    public GameObject rDoor;
    public GameObject bDoor;
    public GameObject wall;
    public GameObject stairsUp;
    public GameObject stairsDown;
	public Material mat;
	GameObject[] tiles = new GameObject[9];
	public GameObject plane;
	GameObject map;
	void Start()
	{
		tiles [0] = basicTile;
		tiles [1] = basicTile;
		tiles [2] = tDoor;
		tiles [3] = lDoor;
		tiles [4] = rDoor;
		tiles [5] = bDoor;
		tiles [6] = wall;
        tiles [7] = stairsDown;
        tiles [8] = stairsUp;
		Instantiate(plane, new Vector3(0, 0, 0), Quaternion.identity);
		map = GameObject.CreatePrimitive (PrimitiveType.Cube);
		
		map.transform.position= new Vector3(14f,7f,1.0f);
		map.transform.localScale = new Vector3 (3f,3f, 0.01f);
		map.GetComponent<MeshRenderer>().material = mat;
		map.tag="Map";
        
        
      /*  for(int r = 0; r < m1.dimensions; ++r){
        for(int c = 0; c < m1.dimensions; ++c){
        Double x = r.doubleValue();
        Double y = c.doubleValue();
        Double rate = 100.0/(m1.dimensions-6);
        Double firstDisparity = Math.abs(((m1.dimensions-1)/2)-r.doubleValue())*rate;
        Double secondDisparity = Math.abs(((m1.dimensions-1)/2)-c.doubleValue())*rate;
        m1.grid[r][c] = 100-(firstDisparity+secondDisparity);*/
    }

   	public void miniMapDisplay(int x,int y,bool currRoom)
	{


		GameObject cube = GameObject.CreatePrimitive (PrimitiveType.Cube);


		//cube.transform.parent = map.transform;
		cube.transform.position= new Vector3(13+x*0.25f,5+y*0.25f,0);
		cube.transform.localScale = new Vector3 (0.15f, 0.15f, 0);
		if (currRoom) {
			cube.transform.localScale = new Vector3 (0.15f, 0.15f, 0.01f);
		}
		cube.transform.parent = map.transform;
	}
	public void displayRoom(Room room, Room[,] layout)
	{
		if (map != null) {
			foreach (Transform child in GameObject.FindWithTag("Map").transform) {
				GameObject.Destroy (child.gameObject);
			}
		}
		for (int i = 0; i < 11; i++)
		{
			for (int m = 0; m < 11; m++)
			{
				// instantate a new tile as child with a unique name
				GameObject tile = (GameObject)Instantiate(tiles[room.roomMatrix[i,m]], new Vector3(i, m, 0), Quaternion.identity);
				tile.transform.parent = GameObject.Find("Plane(Clone)").transform;
				// 0,0 is bottome left hand corner.
				tile.name = "Tile Column:" + i + "Row:" + m;

				//mini map
				if(layout[i,m] != null)
				{
					if(i==room.roomPosition[0]&&m==room.roomPosition[1])
					{
						//miniMapDisplay (i,m,true);
					}else{
					//miniMapDisplay (i,m,false);
					}
				}
			}
		}

	}
    
}

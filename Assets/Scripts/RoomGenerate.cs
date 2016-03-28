using UnityEngine;
using System.Collections;

public class RoomGenerate:MonoBehaviour  {
    
	public GameObject basicTile;
	public GameObject tDoor;
	public GameObject lDoor;
	public GameObject rDoor;
	public GameObject bDoor;
	public GameObject wall;
	public Material mat;
	GameObject[] tiles = new GameObject[7];
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
		Instantiate(plane, new Vector3(0, 0, 0), Quaternion.identity);
	}
   	public void miniMapDisplay(int x,int y)
	{
		GameObject cube = GameObject.CreatePrimitive (PrimitiveType.Cube);
		if (x == 6 && y == 6) 
		{
			map = GameObject.CreatePrimitive (PrimitiveType.Cube);
			
			map.transform.position= new Vector3(14f,7f,1.0f);
			map.transform.localScale = new Vector3 (3f,3f, 0);
			map.GetComponent<MeshRenderer>().material = Red;
		}

		//cube.transform.parent = map.transform;
		cube.transform.position= new Vector3(13+x*0.25f,5+y*0.25f,0);
		cube.transform.localScale = new Vector3 (0.15f, 0.15f, 0);
	}
	public void displayRoom(Room room, Room[,] layout)
	{


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
				miniMapDisplay (i,m);
				}
			}
		}

	}
    
}

using UnityEngine;
using System.Collections;

public class RoomGenerate:MonoBehaviour  {
    
	public GameObject basicTile;
	public GameObject tDoor;
	public GameObject lDoor;
	public GameObject rDoor;
	public GameObject bDoor;
	GameObject[] tiles = new GameObject[6];
	public GameObject plane;
	void Start()
	{
		tiles [0] = basicTile;
		tiles [1] = basicTile;
		tiles [2] = tDoor;
		tiles [3] = lDoor;
		tiles [4] = rDoor;
		tiles [5] = bDoor;
	}
   	public void test(int[] position)
	{
		GameObject cube = GameObject.CreatePrimitive (PrimitiveType.Cube);
		
		cube.transform.position= new Vector3(position[0],position[1]);
	}
	public void displayRoom(Room room)
	{
		Instantiate(plane, new Vector3(0, 0, 0), Quaternion.identity);

		
		for (int i = 0; i < 11; i++)
		{
			for (int m = 0; m < 11; m++)
			{
				// instantate a new tile as child with a unique name
				GameObject tile = (GameObject)Instantiate(tiles[room.roomMatrix[i,m]], new Vector3(i, m, 0), Quaternion.identity);
				tile.transform.parent = GameObject.Find("Plane(Clone)").transform;
				// 0,0 is bottome left hand corner.
				tile.name = "Tile Column:" + i + "Row:" + m;
			}
		}

	}
    
}

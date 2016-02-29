using UnityEngine;
using System.Collections;

public class Room {

	public bool active=false;
	int[] roomPosition= new int[2];   
	int[,] roomMatrix;
	///connections
	//0 = left
	//1 = top
	//2= right
	//3= bottom
	public int[] connectionsToRooms;
	// Use this for initialization
	public Room(int[]position, int[]connections)
	{
		roomMatrix =new int[10, 10];
		roomPosition = position;
		connectionsToRooms = connections;
		GameObject.Find("FloorManager").GetComponent<RoomGenerate>().test (position);

	}


}

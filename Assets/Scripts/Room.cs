using UnityEngine;
using System.Collections;

public class Room {

	public bool active=false;
	const int tileCount = 2;
	int[] roomPosition= new int[2];   
	public int[,] roomMatrix;
	///connections
	//0 = left
	//1 = top
	//2= right
	//3= bottom
	public int[] connectionsToRooms;
	// Use this for initialization
	public Room(int[]position, int[]connections)
	{
		roomMatrix =new int[11, 11];
		roomPosition = position;
		connectionsToRooms = connections;
		//GameObject.Find("FloorManager").GetComponent<RoomGenerate>().test (position);

	}
	public void Generate()
	{

		int xArray = roomMatrix.GetLength(0);
		int yArray = roomMatrix.GetLength(1);
		
		for (int i = 0; i < xArray; i++)
		{
			for (int m = 0; m < yArray; m++)
			{
				if(i==5 && m==0 && connectionsToRooms[3] ==1)
				{
					//add door bottom
					roomMatrix[i,m] = 5;

				}
				else if(i==5 && m==10 && connectionsToRooms[1] ==1)
				{
					//add door top
					roomMatrix[i,m] = 2;
				}
				else if(i==0 && m==5 && connectionsToRooms[0] ==1)
				{
					//add door left
					roomMatrix[i,m] = 3;
				}
				else if(i==10 && m==5 && connectionsToRooms[2] ==1)
				{
					//add door right
					roomMatrix[i,m] = 4;
				}
				else
				{
					//if a wall
					if(i==0||i==10||m==10||m==0)
					{
						//add door right
						roomMatrix[i,m] = 6;
					}
					else // actually do room generation
					{

						Debug.Log("I:"+i+"m:"+m+"chance:"+rockChance(i,m));
						roomMatrix[i,m] = Random.Range(0,tileCount-1);
					}
				}
			}
		}
		
	}
	float rockChance(int itterationX, int itterationY)
	{
		float chance = itterationX + itterationY;
		chance /= 2;
		chance = 5 - chance;
		chance = chance / 121;
		return chance;
	}

}

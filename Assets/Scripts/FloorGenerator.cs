using UnityEngine;
using System.Collections;

public class FloorGenerator : MonoBehaviour {

    public GameObject plane;
	RoomGenerate[,] layout = new RoomGenerate[11,11];
	int[] position = new int[2] {6,6};
	//spritesheet tileSprites
    // Use this for initialization
    void Start () {
    //Load Tilesets& such
		for (int i = 0; i < 11; i++) {
			for (int k = 0; k < 11; k++) {
				layout[i,k] = null;
			}
		}
		GenerateFloor();
    }
	
	// Update is called once per frame
	void Update () {
	// Choose a tile set

    //Generate a floor with that tileset

	}
	void GenerateFloor(){
		// Choose a tile set
		
		//Generate a floor with that tileset
		//Generate a layout plan
		// start at [6,6] which is the center of the "map"
		int[] touching = new int[4];
		//decide if anything is around it
		double touchChance = 0.33;
		//do until there is at least one adjacent room
		while (touching[0]!= 1 || touching[1]!= 1 || touching[2]!= 1 || touching[3]!= 1) {
			for (int i = 0; i < 4; i++) {
				if (touchChance >= Random.Range(0.0f,1.0f) ) {
					touching [i] = 1;
				} else {
					touching [i] = 0;
				}
			}
		}
		
		layout[position[0],position[1]] = new RoomGenerate (position,touching);

		
		//Generate the next room by iterating through the touching of the last room 
		//check all of the array for touching
		///connections
		int[] untouchedPos = position;
		//0 = left
		if (touching [0] == 1) 
		{
			//guarentee position
			position=untouchedPos;
			//check to see if position to the left is a wall
			if(position[0]-1 <0)
			{
			}
			else
			{
				// check if position to the left is occupied
				if(layout[position[0]-1,position[1]] ==null)
				{
				}
				else
				{
					GenerateFloor();
				}
			}
		}
		//1 = top
		if (touching [1] == 1)
		{
			//guarentee position
			position=untouchedPos;
			//check to see if position to the left is a wall
			if(position[1]+1 <10)
			{
			}
			else
			{
				// check if position to the left is occupied
				if(layout[position[0],position[1]+1] ==null)
				{
				}
				else
				{
					GenerateFloor();
				}
			}
		}
		//2= right
		if (touching [2] == 1) 
		{
			//guarentee position
			position=untouchedPos;
			//check to see if position to the left is a wall
			if(position[0]+1 <0)
			{
			}
			else
			{
				// check if position to the left is occupied
				if(layout[position[0]+1,position[1]] ==null)
				{
				}
				else
				{
					GenerateFloor();
				}
			}
		}
		//3= bottom
		if (touching [3] == 1) 
		{
			//guarentee position
			position=untouchedPos;
			//check to see if position to the left is a wall
			if(position[1]-1 <0)
			{
			}
			else
			{
				// check if position to the left is occupied
				if(layout[position[0],position[1]-1] ==null)
				{
				}
				else
				{
					GenerateFloor();
				}
			}
		}
	}


	
}

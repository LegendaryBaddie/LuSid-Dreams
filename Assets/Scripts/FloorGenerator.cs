using UnityEngine;
using System.Collections;

public class FloorGenerator : MonoBehaviour {

   
	public GameObject player;
    public Room[,] layout = new Room[11,11];
	public int[] position = new int[2] {6,6};
	Seed sRand;
	//spritesheet tileSprites
    // Use this for initialization
    void Start () {
    //Load Tilesets& such
		for (int i = 0; i < 11; i++) {
			for (int k = 0; k < 11; k++) {
				layout[i,k] = null;
			}
		}
		//seed
		sRand = new Seed ("zzzzzzzzzzzz");
		//generate floor
		GenerateFloor();
		// generate each room on floor;
		position [0] = 6;
		position [1] = 6;
		gameObject.GetComponent<RoomGenerate> ().displayRoom (layout [6, 6],layout);


    }
	
	// Update is called once per frame
	void Update () {
	// Choose a tile set

    //Generate a floor with that tileset

	}
	int[] addRoom(int[] pos)
	{
		// Choose a tile set
		int[] touching = new int[4];
		//Generate a floor with that tileset
		//Generate a layout plan
		// start at [6,6] which is the center of the "map"

		int touchChance = 50;
		//do until there is at least one adjacent room
		bool empty = false;
		while (empty!=true) {
			for (int i = 0; i < 4; i++) {
				if (touchChance >= sRand.Range (0.0f, 1.0f) * 100) {
					touching [i] = 1;
					empty = true;
				} else {
					touching [i] = 0;
				}
			}
		}
		
		layout[position[0],position[1]] = new Room (position,touching);
		layout[position [0], position [1]].Generate (sRand);
		return touching;

	}
	public void changeRoom(int direction){

		//left
		if (direction == 0) {
			position[0]+=1;
			player.transform.position = new Vector3(8.5f,5,0)  ;
		}
		//top
		else if (direction == 1) {
			position[1]+=1;
			player.transform.position = new Vector3(5,1.5f,0)  ;
		}
		//right
		else if (direction == 2) {
			position[0]-=1;
			player.transform.position = new Vector3(1.5f,5,0)  ;
		}
		//bottom
		else if (direction == 3) {
			position[1]-=1;
			player.transform.position = new Vector3(5,8.5f,0)  ;
		}
		foreach (Transform child in GameObject.Find("Plane(Clone)").transform)
		{
			GameObject.Destroy(child.gameObject);
		}

		gameObject.GetComponent<RoomGenerate> ().displayRoom (layout [position[0], position[1]],layout);

	}
	void GenerateFloor(){
		int[] touching = new int[4];
		touching = addRoom (position);
		//Generate the next room by iterating through the touching of the last room 
		//check all of the array for touching
		///connections
		//int[] untouchedPos = position;
		//0 = left
		int[] untouchedPos = position;
		for (int i =0; i <4; i++) 
		{
			if(i==0&& touching[i] ==1)
			{
					position= untouchedPos;
					if(untouchedPos[0]-1 <0)
					{
					}
					else
					{
						
						// check if position to the left is occupied
						if(layout[untouchedPos[0]-1,untouchedPos[1]]!=null)
						{
						}
						else
						{
							position[0] --;
							GenerateFloor();
						}
					}
			}


			if(i==1&& touching[i] ==1)
			{
				position= untouchedPos;
				if(untouchedPos[1]+1 >10)
				{
				}
				else
				{

					// check if position to the left is occupied
					if(layout[untouchedPos[0],untouchedPos[1]+1]!=null)
					{
					}
					else
					{

						position[1] ++;
						GenerateFloor();
					}
				}
			}
			if(i==2&& touching[i] ==1)
			{
				position= untouchedPos;
				if(untouchedPos[0]+1 >10)
				{
				}
				else
				{

					// check if position to the left is occupied
					if(layout[untouchedPos[0]+1,untouchedPos[1]]!=null)
					{
					}
					else
					{
						position[0] ++;
						GenerateFloor();
					}
				}
			}
			if(i==3&& touching[i] ==1)
			{
				position= untouchedPos;
				if(untouchedPos[1]-1 <0)
				{
				}
				else
				{

					// check if position to the left is occupied
					if(layout[untouchedPos[0],untouchedPos[1]-1]!=null)
					{
					}
					else
					{
						position[1] --;
						GenerateFloor();
					}
				}
			}		
		}
	}
}

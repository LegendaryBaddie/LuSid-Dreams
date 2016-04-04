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
		addRoom (position);
		GenerateFloor();
		// generate each room on floor;
		position [0] = 6;
		position [1] = 6;
		for(int i=0;i<11;i++){
			for(int m=0;m<11;m++)
			{
				if(layout[i,m]!=null)
				{
					Debug.Log("room " +layout[i,m].roomPosition[0]+","+layout[i,m].roomPosition[1] + " left: "+layout[i,m].connectionsToRooms[0]+" top: "+layout[i,m].connectionsToRooms[1]+" right: "+layout[i,m].connectionsToRooms[2]+" bottom: "+layout[i,m].connectionsToRooms[3]);
				}
			}
		}
		gameObject.GetComponent<RoomGenerate> ().displayRoom (layout [6, 6],layout);

		//debug


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


		//check if room has adjacent depenencies



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
		
		layout[pos[0],pos[1]] = new Room (pos,touching);
		layout[pos[0], pos[1]].Generate (sRand);

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

		//Generate the next room by iterating through the touching of the last room 
		//check all of the array for touching
		///connections
		//int[] untouchedPos = position;
		//0 = left
		for (int i = 0; i < 11; i++) {
			for (int k = 0; k < 11; k++) {
			if(layout[i,k]!=null)
				{
					int[] tempPos= new int[2];
					if(layout[i,k].connectionsToRooms[0]==1)
					{
					
						if(i==0)
						{
							continue;
						}else{
						tempPos[0]=i-1;
						tempPos[1]=k;
						addRoom(tempPos);
						}
					}
					if(layout[i,k].connectionsToRooms[1]==1)
					{
						
						if(k==0)
						{
							continue;
						}else{
							tempPos[0]=i;
							tempPos[1]=k-1;
							addRoom(tempPos);
						}
					}
					if(layout[i,k].connectionsToRooms[2]==1)
					{
						
						if(i>9)
						{
							continue;
						}else{
							tempPos[0]=i+1;
							tempPos[1]=k;
							addRoom(tempPos);
						}
					}
					if(layout[i,k].connectionsToRooms[3]==1)
					{
						
						if(k>9)
						{
							continue;
						}else{
							tempPos[0]=i;
							tempPos[1]=k+1;
							addRoom(tempPos);
						}
					}
				}
			}
		}
		for (int i = 0; i < 11; i++) {
			for (int k = 0; k < 11; k++) {
				if(i>0 && i<10 && k>0 && k<10)
				{
					if(layout[i,k]!=null){
					if(layout[i,k].connectionsToRooms[0]==1)
					{
						if(layout[i-1,k]==null)
						{
							GenerateFloor();
						}
					}
					if(layout[i,k].connectionsToRooms[1]==1)
					{
						if(layout[i,k-1]==null)
						{
							GenerateFloor();
						}
					}
					if(layout[i,k].connectionsToRooms[2]==1)
					{
						if(layout[i+1,k]==null)
						{
							GenerateFloor();
						}
					}
					if(layout[i,k].connectionsToRooms[3]==1)
					{
						if(layout[i,k+1]==null)
						{
							GenerateFloor();
						}
					}

				}
				}
			}
		}
		
	}
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class FloorGenerator : MonoBehaviour {

   
	public GameObject player;
    public Room[,] layout = new Room[11,11];
	public int[] position = new int[2] {6,6};
	Stack<int[]> lastCheck= new Stack<int[]>();
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
		gameObject.GetComponent<RoomGenerate> ().displayRoom (layout [6,6],layout);

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
		if (pos [0] > 0 &&  pos [1] > 0) {
			if (layout [pos [0] - 1, pos [1]] != null) {
				if (layout [pos [0] - 1, pos [1]].connectionsToRooms [2] == 1) {
					touching [0] = 1;
				}
			}
			if (layout [pos [0], pos [1] - 1] != null) {
				if (layout [pos [0], pos [1] - 1].connectionsToRooms [1] == 1) {
					touching [3] = 1;
				}
			}
        }
            if(pos[0]<10 && pos[1]<10)
            {
            if (layout [pos [0] + 1, pos [1]] != null) {
				if (layout [pos [0] + 1, pos [1]].connectionsToRooms [0] == 1) {
					touching [2] = 1;
				}
			}
			if (layout [pos [0], pos [1] + 1] != null) {
				if (layout [pos [0], pos [1] + 1].connectionsToRooms [3] == 1) {
					touching [1] = 1;
				}
			}
		}
		int touchChance = 33;
		//do until there is at least one adjacent room

			for (int i = 0; i < 4; i++) {
			if(touching[i]==1)
			{continue;}
				if (touchChance >= sRand.Range (0.0f, 1.0f) * 100) {
					touching [i] = 1;
					
				} else {
					touching [i] = 0;
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
			player.transform.position = new Vector3(1.1f,5,0)  ;
		}
		//top
		else if (direction == 1) {
			position[1]+=1;
			player.transform.position = new Vector3(5,1.5f,0)  ;
		}
		//right
		else if (direction == 2) {
			position[0]-=1;
			player.transform.position = new Vector3(8.9f,5,0)  ;
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
		while (true) {
			if (layout [position [0], position [1]] != null) {
                if(position[0]>=1 &&position[1] >=1){
                    //left
				if (layout [position [0], position [1]].connectionsToRooms [0] == 1 &&layout[position[0]-1,position[1]]==null) {
					
                    addRoom (new int[]{position [0] - 1, position [1]});
                        Debug.Log(position[0]+","+position[1]);
					lastCheck.Push(new int[]{position [0], position [1]});
					position[0]--;
					continue;
				}
                //bottom
				if (layout [position [0], position [1]].connectionsToRooms [1] == 1 &&layout[position[0],position[1]+1]==null) {
					addRoom (new int[]{position [0], position [1]+1});
                        Debug.Log(position[0]+","+position[1]);
					lastCheck.Push(new int[]{position [0], position [1]});
					position[1]++;
					continue;
				}
                //right
				if (layout [position [0], position [1]].connectionsToRooms [2] == 1 &&layout[position[0]+1,position[1]]==null) {
					addRoom (new int[]{position [0]+1, position [1]});
                        Debug.Log(position[0]+","+position[1]);
					lastCheck.Push(new int[]{position [0], position [1]});
					position[0]++;
					continue;
				}
                //top
				if (layout [position [0], position [1]].connectionsToRooms [3] == 1 &&layout[position[0],position[1]-1]==null) {
					addRoom (new int[]{position [0], position [1]-1});
                        Debug.Log(position[0]+","+position[1]);
					lastCheck.Push(new int[]{position [0], position [1]});
					position[1]--;
					continue;
				}
               // if nothing left pop back one
               if(lastCheck.Count>1)
               {
               lastCheck.Pop();
               int[] a = lastCheck.Peek();
               position[0]=a[0];
               position[1]=a[1];
               Debug.Log("backd one"+a[0]+","+a[1]);
               continue;
               }
              
              }
              {
                if(lastCheck.Count>1)
               {
               lastCheck.Pop();
               int[] a = lastCheck.Peek();
               position[0]=a[0];
               position[1]=a[1];
               Debug.Log("backd one"+a[0]+","+a[1]);
               continue;
               }
              
              }
			}
            
            break;
		}
       
            
		
	}	
}

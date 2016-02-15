using UnityEngine;
using System.Collections;

public class FloorGenerator : MonoBehaviour {

    public GameObject plane;
	RoomGenerate[,] layout = new RoomGenerate[11,11];
	//spritesheet tileSprites
    // Use this for initialization
    void Start () {
    //Load Tilesets& such

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
		int[,] position = new int[1, 1]{{6,6}};
		int[] touching = new int[4];
		//decide if anything is around it
		double touchChance = 0.33;
		//do until there is at least one adjacent room
		while (touching[0]!= 1 || touching[1]!= 1 || touching[2]!= 1 || touching[3]!= 1) {
			for (int i = 0; i < 4; i++) {
				if (touchChance >= Random.NextDouble ()) {
					touching [i] = 1;
				} else {
					touching [i] = 0;
				}
			}
		}
		
		layout [6, 6] = new RoomGenerate (position, touching);
		//Generate the next room by iterating through the touching of the last room 

	}


	
}
f
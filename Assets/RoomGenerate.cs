using UnityEngine;
using System.Collections;

public class RoomGenerate : MonoBehaviour {
    public GameObject basicTile;
    public GameObject plane;
    int[,] roomMaxtrix =new int[10, 10];
    // Use this for initialization
    void Start () {
     int xArray = roomMaxtrix.GetLength(0);
     int yArray = roomMaxtrix.GetLength(1);
    
    for (int i=0; i<xArray;i++)
        {
            for (int m = 0; m < yArray; m++)
            {
                Instantiate(basicTile,new Vector3(i , m,0), Quaternion.identity);
                
            }
        }

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}

using UnityEngine;
using System.Collections;

public class RoomGenerate : MonoBehaviour {
    public GameObject basicTile;
    public GameObject plane;
   
    int[,] roomMaxtrix =new int[10, 10];
    // Use this for initialization
    void Start () {
    
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    public void Generate()
    {
        Instantiate(plane, new Vector3(0, 0, 0), Quaternion.identity);
        int xArray = roomMaxtrix.GetLength(0);
        int yArray = roomMaxtrix.GetLength(1);

        for (int i = 0; i < xArray; i++)
        {
            for (int m = 0; m < yArray; m++)
            {
                // instantate a new tile as child with a unique name
                GameObject tile = (GameObject)Instantiate(basicTile, new Vector3(i, m, 0), Quaternion.identity);
                tile.transform.parent = GameObject.Find("Plane(Clone)").transform;
                // 0,0 is bottome left hand corner.
                tile.name = "Tile Column:" + i + "Row:" + m;
            }
        }

    }
}

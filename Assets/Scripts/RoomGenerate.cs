using UnityEngine;
using System.Collections;

public class RoomGenerate:MonoBehaviour  {
    
	public GameObject basicTile;
	public GameObject plane;
   	public void test(int[] position)
	{
		GameObject cube = GameObject.CreatePrimitive (PrimitiveType.Cube);
		
		cube.transform.position= new Vector3(position[0],position[1]);
	}

    public void Generate(int[,] roomMatrix)
    {
        Instantiate(plane, new Vector3(0, 0, 0), Quaternion.identity);
        int xArray = roomMatrix.GetLength(0);
        int yArray = roomMatrix.GetLength(1);

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

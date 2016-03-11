using UnityEngine;
using System.Collections;

public class TestPlayerMovement : MonoBehaviour {

	public float speed = 1.5f;
	public GameObject enemyPrefab;
	public int numOfEnemies;
	int randNum;

	// Use this for initialization
	void Start () {

		for (int i = 1; i < numOfEnemies + 1; i++) {
			//Get random coordinates
			randNum = Random.Range(1,10);

			//Instantiate enemy on start
			Instantiate (enemyPrefab, new Vector3 (randNum, randNum, 0), Quaternion.identity);
		}

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			transform.position += Vector3.left * speed * Time.deltaTime;
		}
		else if (Input.GetKey(KeyCode.RightArrow))
		{
			transform.position += Vector3.right * speed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.UpArrow))
		{
			transform.position += Vector3.up * speed * Time.deltaTime;
		}
		else if (Input.GetKey(KeyCode.DownArrow))
		{
			transform.position += Vector3.down * speed * Time.deltaTime;
		}
	
	}

	void OnTriggerEnter2D(Collider2D obj){
		if (obj.tag=="TDoor")
		{
			Debug.Log("sdfgdsds");
			GameObject.Find("FloorManager").GetComponent<FloorGenerator>().changeRoom(1);
		}
		else if (obj.tag=="RDoor")
		{
			Debug.Log("sdfgdsds");
			GameObject.Find("FloorManager").GetComponent<FloorGenerator>().changeRoom(0);
		}
		else if (obj.tag=="LDoor")
		{
			Debug.Log("sdfgdsds");
			GameObject.Find("FloorManager").GetComponent<FloorGenerator>().changeRoom(2);
		}
		else if (obj.tag=="BDoor")
		{
			Debug.Log("sdfgdsds");
			GameObject.Find("FloorManager").GetComponent<FloorGenerator>().changeRoom(3);
		}

	}


}

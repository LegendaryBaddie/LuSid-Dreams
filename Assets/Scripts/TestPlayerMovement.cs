using UnityEngine;
using System.Collections;

public class TestPlayerMovement : MonoBehaviour {

	public float speed = 1.5f;
	public GameObject enemyPrefab;
	public int numOfEnemies;
	public GameObject shooterBarrel;
	public GameObject prefab;
	GameObject projectile;
	int randNum;
	Vector3 mousePos;

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
	void Update () 
	{
		//Rotate player towards mouse direction
		/*mousePos = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 0);
		transform.LookAt (mousePos);*/


		//FOR PLAYER INPUT
		if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
			transform.position += Vector3.left * speed * Time.deltaTime;
		else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
			transform.position += Vector3.right * speed * Time.deltaTime;
		if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
			transform.position += Vector3.up * speed * Time.deltaTime;
		else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
			transform.position += Vector3.down * speed * Time.deltaTime;
		//If mouse click then shoot 
		if (Input.GetMouseButtonDown(0))
			projectile = (GameObject)Instantiate(prefab, shooterBarrel.transform.position, Quaternion.identity);

		//After 1 second destory projectile
		Destroy (projectile, 3.0f);
	
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

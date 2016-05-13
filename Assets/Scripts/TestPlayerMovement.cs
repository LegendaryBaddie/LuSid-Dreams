using UnityEngine;
using System.Collections;

public class TestPlayerMovement : MonoBehaviour {

	public float speed = 1.5f;
	public GameObject enemyPrefab;
	public int numOfEnemies;
	public GameObject shooterBarrel;
	public GameObject prefab;
	public Sprite human;
	public int health;
	GameObject projectile;
	int randNum;
	Vector3 mousePos;
	Sprite[] charSpriteArray = new Sprite[10];

	// Use this for initialization
	void Start () {
		//Set health
		health = 100;

		//Fill character sprite array with starter
		charSpriteArray[0] = human;

		//Set character sprite
		transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = charSpriteArray[0];

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

		//Update Bar
		updateHealthBar();
	
	}

	//Function that updates the health bar based on health
	void updateHealthBar(){
		float newBarSize = transform.GetChild(2).localScale.x * (health/100);
		transform.GetChild (2).localScale = new Vector3 (newBarSize, transform.GetChild (2).localScale.y, transform.GetChild (2).localScale.z);
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
        else if (obj.tag=="Stairs")
		{
			Debug.Log("sdfgdsds");
			GameObject.Find("FloorManager").GetComponent<FloorGenerator>().changeFloor();
		}
	}

	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "Collectable") {
			//Get Sprite info
			transform.GetChild (0).gameObject.GetComponent<SpriteRenderer> ().sprite = col.GetComponent<CollectableScript> ().spriteInfo;

			Destroy (col.gameObject);
		}
	}

}

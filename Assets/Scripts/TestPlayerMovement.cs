using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TestPlayerMovement : MonoBehaviour {

	public float speed = 1.5f;
	/*public GameObject enemyPrefab;
	public int numOfEnemies;*/
	public GameObject shooterBarrel;
	public GameObject prefab;
	public Sprite human;
	public Sprite projSprite;
	public int health;
	public bool hasBeenHit;

	GameObject projectile;
	//int randNum;
	Vector3 mousePos;
	List<Sprite> charSpriteArray = new List<Sprite>();
	float barSize;
	public float newBarSize;

	// Use this for initialization
	void Start () {
		//Set health
		health = 100;

		//Fill character sprite array with starter
		charSpriteArray.Add(human);

		//Set character sprite
		transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = charSpriteArray[0];

		/*for (int i = 1; i < numOfEnemies + 1; i++) {
			//Get random coordinates
			randNum = Random.Range(1,10);

			//Instantiate enemy on start
			Instantiate (enemyPrefab, new Vector3 (randNum, randNum, 0), Quaternion.identity);
		}*/

		barSize = transform.GetChild(2).localScale.x;
		newBarSize = barSize;

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
		if (Input.GetMouseButtonDown (0)) {
			projectile = (GameObject)Instantiate (prefab, shooterBarrel.transform.position, Quaternion.identity);
			projectile.GetComponent<BulletMovement>().spriteInfo = projSprite;
		}

		//After 1 second destory projectile
		Destroy (projectile, 3.0f);

		//Update Bar
		updateHealthBar();
	
	}

	//Function that updates the health bar based on health
	void updateHealthBar(){
		//Update size
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

	//Collision check for collectables
	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "Collectable") {
			transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = col.GetComponent<CollectableScript> ().spriteInfo;
			projSprite = col.GetComponent<CollectableScript> ().spriteInfoProj;
			//USED IN LATER GAME
			/*//Variable to check if sprite is already in list
			bool alreadyIn = false;

			//Check through list
			foreach(Sprite sprites in charSpriteArray){
				if(sprites == col.GetComponent<CollectableScript> ().spriteInfo){
					alreadyIn = true;
				}
			}

			//If it isnt already in the list then add
			if(!alreadyIn){
				charSpriteArray.Add(col.GetComponent<CollectableScript> ().spriteInfo);
			}*/
			

			Destroy (col.gameObject);
		}
	}

}

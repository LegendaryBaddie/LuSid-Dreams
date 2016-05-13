using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

	GameObject player;
	public float speed;
	GameObject sprite;
	bool hasEntered;
	bool flipTime;
	bool firstTime;

	//For hit collision
	bool hasBeenHit = false;
	float timer = 3;

	//For wander
	float wanderRadius = 5.0f;
	Vector3 destination = Vector3.zero;
	Vector2 randomCirclePoint;
	public float rotationSpeed;
	private Quaternion lookRotation;
	private Vector3 direction;
	bool changeDirection;

	Vector3 rightRotate = new Vector3(0,180,0);
	int count = 0;

	float step;

	// Use this for initialization
	void Start () {
		speed = 1;
		hasEntered = false;
		wander ();
		step = speed * Time.deltaTime;
		player = GameObject.FindGameObjectWithTag("Player");
		rotationSpeed = 5;
		sprite =  GameObject.FindWithTag("EnemySprite");
		flipTime = true;
		firstTime = true;

		//On start get new destination for wander
		randomCirclePoint = Random.insideUnitCircle * wanderRadius;
		destination = new Vector3 (randomCirclePoint.x, randomCirclePoint.y, 0);
		changeDirection = false;
		
	}
	
	// Update is called once per frame
	void Update () {
		//If the player enters the range...seek
		if (hasEntered) {
			seek ();
		} 
		else {
			wander ();
		}

	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Player") {
			hasEntered = true;
		} 

	}

	//Function that gives enemy a random path
	void wander(){
		if (transform.position == destination) {
			//Getting new destination
			randomCirclePoint = Random.insideUnitCircle * wanderRadius;
			destination = new Vector3 (randomCirclePoint.x, randomCirclePoint.y, 0);
			flipTime = true;
		}

		//Rotate
		direction = (destination - transform.position).normalized;
		lookRotation = Quaternion.LookRotation (direction);
		lookRotation.x = 0;
		lookRotation.y = 0;

		//If the destination is to the right
		if ((destination.x - transform.position.x) > 0 && flipTime) {
			transform.localScale = new Vector3 (transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
		}
		else if(flipTime && !firstTime){
			transform.localScale = new Vector3 (transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
		}
		
		transform.rotation = Quaternion.Slerp (transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
		transform.position = Vector3.MoveTowards (transform.position, destination, step * 0.5f);
		flipTime = false;
		firstTime = false;
	}

	//Function that seeks the player
	void seek(){
		//Seek Player
		transform.position = Vector3.MoveTowards (transform.position, player.transform.position, step);

		//Rotate Towards Player
		direction = (player.transform.position - transform.position).normalized;
		lookRotation = Quaternion.LookRotation (direction);
		lookRotation.x = 0;
		lookRotation.y = 0;
		
		//If the destination is to the right
		if ((player.transform.position.x - transform.position.x) > 0 && flipTime) {
			transform.localScale = new Vector3 (transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
		}
		else if(flipTime && !firstTime){
			transform.localScale = new Vector3 (transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
		}

		transform.rotation = Quaternion.Slerp (transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);

		//Check if enemy is within range to attack player
		float playerX = player.transform.position.x;
		float playerY = player.transform.position.y;
		float enemyX = transform.position.x;
		float enemyY = transform.position.y;

		//If not in seeking range
		if(Mathf.Abs(enemyX - playerX) > 3.5){
			hasEntered = false;
		}
		if(Mathf.Abs(enemyY - playerY) > 3.5){
			hasEntered = false;
		}

		//If in attacking range

		//Attack
		if(Mathf.Abs(enemyX - playerX) == 0){
			attack(player);
		}
		if(Mathf.Abs(enemyY - playerY) == 0){
			attack(player);
		}
	}

	//Attack function that gives damage to player health
	void attack(GameObject player){
		//If the player hasn't been hit in 3 seconds
		if (!hasBeenHit) {
			//Push player back
			player.transform.position = new Vector3 (player.transform.position.x - 0.9f, player.transform.position.y, player.transform.position.z);
			//Give damage
			player.GetComponent<TestPlayerMovement> ().health -= 10;
			player.GetComponent<TestPlayerMovement> ().newBarSize += 0.05f;
			hasBeenHit = true;
		}

		//Timer for hasBeenHit
		if (countDown()==true) {
			hasBeenHit = false;
		}
	}

	bool countDown(){
		timer -= Time.deltaTime;
		
		if (timer > 0) {
			return false;
		}
		else {
			timer = 3;
			return true;
		}
		
	}



}

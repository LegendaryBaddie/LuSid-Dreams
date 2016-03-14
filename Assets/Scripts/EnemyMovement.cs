using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

	GameObject player;
	public float speed;
	bool hasEntered;

	//For wander
	float wanderRadius = 5.0f;
	Vector3 destination = Vector3.zero;
	Vector2 randomCirclePoint;
	public float rotationSpeed;
	private Quaternion lookRotation;
	private Vector3 direction;
	bool changeDirection;

	float step;

	// Use this for initialization
	void Start () {
		speed = 1;
		hasEntered = false;
		wander ();
		step = speed * Time.deltaTime;
		player = GameObject.FindGameObjectWithTag("Player");
		rotationSpeed = 5;

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
			if(!changeDirection){changeDirection = true;}
			if(changeDirection){changeDirection = false;}

		}

		//Rotate
		direction = (destination - transform.position).normalized;
		lookRotation = Quaternion.LookRotation (direction);
		lookRotation.x = 0;
		lookRotation.y = 0;
		if(changeDirection){
			lookRotation.z = -lookRotation.z;
		}
		
		transform.rotation = Quaternion.Slerp (transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
		transform.position = Vector3.MoveTowards (transform.position, destination, step * 0.5f);
	}

	//Function that seeks the player
	void seek(){
		//Seek Player
		transform.position = Vector3.MoveTowards (transform.position, player.transform.position, step);

		//Rotate Towards Player


		//Check if enemy is within range to attack player
		float playerX = player.transform.position.x;
		float playerY = player.transform.position.y;
		float enemyX = transform.position.x;
		float enemyY = transform.position.y;

		if(Mathf.Abs(enemyX - playerX) > 3.5){
			hasEntered = false;
		}
		if(Mathf.Abs(enemyY - playerY) > 3.5){
			hasEntered = false;
		}
	}



}

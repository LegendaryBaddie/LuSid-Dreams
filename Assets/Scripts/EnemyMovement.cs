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
			/*if(!changeDirection){changeDirection = true;}
			if(changeDirection){changeDirection = false;}*/

		}

		//Rotate
		direction = (destination - transform.position).normalized;
		lookRotation = Quaternion.LookRotation (direction);
		lookRotation.x = 0;
		lookRotation.y = 0;
		//If the destination is to the right
		if((destination.x - transform.position.x)>0){
			/*if(lookRotation.z < 0){lookRotation.z = lookRotation.z - .5f;}
			else{lookRotation.z = lookRotation.z + .5f;}*/
			//lookRotation.z = -lookRotation.z;

		}
		
		transform.rotation = Quaternion.Slerp (transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
		transform.position = Vector3.MoveTowards (transform.position, destination, step * 0.5f);
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


		/*if ((player.transform.position.x - transform.position.x) > 0)
		{
			//lookRotation.y = 180;

			transform.rotation = Quaternion.Euler (new Vector3 (0, count, lookRotation.z));
			count++;
			print(transform.rotation);
		} 
		else 
		{
			//transform.rotation = Quaternion.Euler (new Vector3 (0, 0, lookRotation.z));
		}*/

		
		/*transform.rotation = Quaternion.Euler (new Vector3 (0, 0, count));
		count++;
		print(transform.rotation);*/


		transform.rotation = Quaternion.Slerp (transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);

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

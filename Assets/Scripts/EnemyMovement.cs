using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

	GameObject player;
	public float speed;
	bool hasEntered;


	float wanderRadius = 5.0f;
	Vector3 destination = Vector3.zero;
	Vector3 newDir;

	Vector3 wayPoint;
	float step;

	// Use this for initialization
	void Start () {
		speed = 1;
		hasEntered = false;
		wander ();
		step = speed * Time.deltaTime;
		player = GameObject.FindGameObjectWithTag("Player");
		
	}
	
	// Update is called once per frame
	void Update () {

		//print ((transform.position - wayPoint).magnitude);


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
		/*if (transform.position == wayPoint) {
			wayPoint = Random.insideUnitSphere;
			wayPoint = transform.position + wayPoint;
			wayPoint.z = 0;
		}
		transform.position = Vector3.MoveTowards (transform.position, wayPoint, step * 0.5f);*/



		if (transform.position == destination) {
			//Getting new destination
			Vector2 randomCirclePoint = Random.insideUnitCircle * wanderRadius;
			destination = new Vector3 (randomCirclePoint.x, randomCirclePoint.y, 0);

			// = new Vector2(transform.position.x, transform.position.y);

		}
		/*transform.position = Vector3.MoveTowards (transform.position, destination, step * 0.5f);
		Vector3 newDir = Vector3.RotateTowards(playerVec, destination, step * 0.5f, 0.0F);*/
		//Getting rotation
		float angle = Mathf.Atan2(destination.y, destination.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);


		/*Vector2 destinationVec = new Vector2 (destination.x, destination.y);
		float angle = Vector2.Angle (playerVec, destinationVec);
		transform.rotation = Quaternion.LookRotation(newDir, Vector3.up);
		print (newDir);*/
	}

	//Function that seeks the player
	void seek(){
		//Seek Player
		transform.position = Vector3.MoveTowards (transform.position, player.transform.position, step);
		print("entered");
		//Rotate Towards Player
		/*Vector3 playerDir = player.transform.position - transform.position;
		Vector3 newDir = Vector3.RotateTowards(transform.forward, playerDir, step, 0.0F);
		transform.rotation = Quaternion.LookRotation(newDir);*/

		//Check if enemy is within range to attack player
		float playerX = player.transform.position.x;
		float playerY = player.transform.position.y;
		float enemyX = transform.position.x;
		float enemyY = transform.position.y;
		
		if(Mathf.Abs(enemyX - playerX) > 0.5){
			print("left");
			hasEntered = false;
		}
		if(Mathf.Abs(enemyY - playerY) > 0.5){
			print("left");
			hasEntered = false;
		}
	}



}

using UnityEngine;
using System.Collections;

public class BulletMovement : MonoBehaviour {

	GameObject player;
	int damage;
	int speed;

	// Use this for initialization
	void Start () 
	{
		damage = 33;
		speed = 5;
		player =  GameObject.FindGameObjectWithTag("ProjStart");
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.position += player.transform.right * Time.deltaTime * speed;
	}

	//Check Collision with enemy
	/*void onTriggerEnter(Collider col){
		print ("Here");

		//Deal damage to enemy
		if (col.gameObject.tag == "Enemy") 
			col.gameObject.GetComponent<EnemyAttributes>().takeDamage(10);
	}*/

	void OnCollisionEnter(Collision col) {
		if (col.gameObject.tag == "Enemy")
			Destroy (gameObject);
			col.gameObject.GetComponent<EnemyAttributes>().takeDamage(damage);
	}


}

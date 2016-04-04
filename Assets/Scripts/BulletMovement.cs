using UnityEngine;
using System.Collections;

public class BulletMovement : MonoBehaviour {

	GameObject player;
	//GameObject[] Enemys;
	int speed;

	// Use this for initialization
	void Start () 
	{
		speed = 5;
		player =  GameObject.FindGameObjectWithTag("ProjStart");
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.position += player.transform.right * Time.deltaTime * speed;
	}

	//Check Collision with enemy
	void onTriggerEnter(Collider col){
		print ("Here");

		//Deal damage to enemy
		if (col.gameObject.tag == "Enemy") 
			col.gameObject.GetComponent<EnemyAttributes>().takeDamage(10);

	}
}

using UnityEngine;
using System.Collections;

public class EnemyAttributes : MonoBehaviour {

	public GameObject collectPrefab;
	public Sprite projSprite;
	GameObject collectable;
	string enemeyType;
	int attackDamage;
	int health;

	// Use this for initialization
	void Start () 
	{
		health = 100;

		//Determine the attack Damage based on the enemy type
		if (enemeyType == "normal") 
		{
			attackDamage = 10;
		}
		else 
		{
			attackDamage = 5;
		}
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		//Destroy the enemy if it is dead
		if (isDead()) {
			dropCollectable();
			Destroy(gameObject);
		}
	}

	//Function that takes in an amount of damage to deal to enemy
	public void takeDamage(int damage)
	{
		health -= damage;
	}

	//Function that drops a collectable
	void dropCollectable(){
		//30% Drop rate
		int randNum = Random.Range(1,10);

		//Instantiate if correct
		if (randNum <= 3) {
			collectable = Instantiate (collectPrefab, transform.position, Quaternion.identity) as GameObject;

			//Get Sprite info
			GameObject child = transform.GetChild(1).gameObject;
			SpriteRenderer sr = child.GetComponent<SpriteRenderer>();
			collectable.GetComponent<CollectableScript>().spriteInfo = sr.sprite;
			collectable.GetComponent<CollectableScript>().spriteInfoProj = projSprite;
		}
	}

	//Function that checks if the enemy is dead
	bool isDead(){
		if (health <= 0) {
			return true;
		} 
		else {
			return false;
		}
	}
}

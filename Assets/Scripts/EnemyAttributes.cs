using UnityEngine;
using System.Collections;

public class EnemyAttributes : MonoBehaviour {

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
			Destroy(gameObject);
		}
	}

	//Function that takes in an amount of damage to deal to enemy
	public void takeDamage(int damage)
	{
		health -= damage;
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

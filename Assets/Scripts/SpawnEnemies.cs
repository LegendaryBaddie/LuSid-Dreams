using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnEnemies : MonoBehaviour {

	public GameObject enemyPrefab;
	int numOfEnemies;
	public List<Sprite> enemSpriteArray = new List<Sprite>();
	public List<Sprite> projSpriteArray = new List<Sprite>();
	GameObject enemy;
	int randNum;
	int randEnemNum;


	// Use this for initialization
	void Start () {
		//RANDOM ENEMY SPRITE
		randEnemNum = Random.Range(0,6);
		numOfEnemies = Random.Range (1, 6);

		for (int i = 1; i < numOfEnemies + 1; i++) {
			//Get random coordinates
			randNum = Random.Range(1,10);
			
			//Instantiate enemy on start
			enemy = Instantiate (enemyPrefab, new Vector3 (randNum, randNum, 0), Quaternion.identity) as GameObject;
			enemy.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = enemSpriteArray[randEnemNum];
			enemy.GetComponent<EnemyAttributes>().projSprite = projSpriteArray[randEnemNum];
		}
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

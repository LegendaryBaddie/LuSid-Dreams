using UnityEngine;
using System.Collections;

public class BulletMovement : MonoBehaviour {

	GameObject player;
	int damage;
	int speed;
	public Sprite spriteInfo;
	public SpriteRenderer sr;

	// Use this for initialization
	void Start () 
	{
		print (spriteInfo);
		damage = 33;
		speed = 5;
		player =  GameObject.FindGameObjectWithTag("ProjStart");
		sr.sprite = spriteInfo;
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.position += player.transform.right * Time.deltaTime * speed;
	}

	void OnCollisionEnter(Collision col) {
		if (col.gameObject.tag == "Enemy")
			Destroy (gameObject);
			col.gameObject.GetComponent<EnemyAttributes>().takeDamage(damage);
	}


}

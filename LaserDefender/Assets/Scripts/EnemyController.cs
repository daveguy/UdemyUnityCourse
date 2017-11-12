using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	public int health = 3;
	public GameObject laser;
	public float shotSpeed;
	public float fireRate = 1f;

	private float timeTillFire;

	void Start(){
		timeTillFire = fireRate + (Random.value - 0.5f);
	}

	void Update(){
		timeTillFire -= Time.deltaTime;
		if (timeTillFire <= 0) {
			Fire ();
			timeTillFire = fireRate + (Random.value - 0.5f);
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		LaserController laser = other.gameObject.GetComponent<LaserController> ();
		if(laser.getType() == LaserType.PLAYER){
			Hit (laser.getDamage());
			laser.Destroy ();
		}
	}

	void Hit(int damage){
		health -= damage;
		if (health <= 0) {
			Destroy (this.gameObject);
		}
	}

	void Fire(){
		GameObject beam = Instantiate (laser, transform.position - new Vector3(0f,0.6f,0f), Quaternion.identity) as GameObject;
		beam.GetComponent<Rigidbody2D> ().velocity = new Vector2(0, -shotSpeed);
		beam.GetComponent<LaserController> ().setType (LaserType.ENEMY);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed = 5.0f;
	public GameObject laser;
	public float shotSpeed;
	public float firingRate;

	private Vector3 corner;
	// Use this for initialization
	void Start () {
		float distance = transform.position.z - Camera.main.transform.position.z;
		corner = Camera.main.ViewportToWorldPoint (new Vector3 (1,1,distance));
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow)){
			moveShip ();		
		}

		if (Input.GetKeyDown (KeyCode.Space)) {
			InvokeRepeating ("Fire", 0.0001f, firingRate);
		}

		if (Input.GetKeyUp (KeyCode.Space)) {
			CancelInvoke ();
		}
	}

	void moveShip(){
		if (Input.GetKey(KeyCode.LeftArrow)) {
			transform.position += Vector3.left * speed * Time.deltaTime;
		} else if (Input.GetKey(KeyCode.RightArrow)) {
			transform.position += Vector3.right * speed * Time.deltaTime;
		}

		if (Input.GetKey(KeyCode.UpArrow)) {
			transform.position += Vector3.up * speed * Time.deltaTime;
		} else if (Input.GetKey(KeyCode.DownArrow)) {
			transform.position += Vector3.down * speed * Time.deltaTime;
		}
		transform.position = new Vector3 (Mathf.Clamp (transform.position.x, -corner.x + 0.5f, corner.x - 0.5f), Mathf.Clamp (transform.position.y, -corner.y + 0.5f, corner.y - 0.5f), transform.position.z);
	}

	void Fire(){
		GameObject beam = Instantiate (laser, transform.position + new Vector3(0f,0.5f,0f), Quaternion.identity) as GameObject;
		beam.GetComponent<Rigidbody2D> ().velocity = new Vector2(0, shotSpeed);
	}
}

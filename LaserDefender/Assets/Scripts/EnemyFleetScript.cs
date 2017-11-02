using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFleetScript : MonoBehaviour {

	public GameObject enemy;
	public float width = 10f;
	public float height = 5f;
	public float fleetSpeed = 5;

	private Vector3 direction = Vector3.left;
	private Vector3 edge;
	// Use this for initialization
	void Start () {
		edge = Camera.main.ViewportToWorldPoint (new Vector3 (1, 1, 0));
		foreach (Transform t in transform) {
			GameObject newEnemy = Instantiate (enemy, t.position, Quaternion.identity) as GameObject;
			newEnemy.transform.parent = t;
			newEnemy.SetActive (true);
		}
	}
	void OnDrawGizmos(){
		Gizmos.DrawWireCube(transform.position, new Vector3(width, height));
	}

	// Update is called once per frame
	void Update () {
		MoveFleet ();
	}

	void MoveFleet(){
		if ((transform.position.x + width*0.5f > edge.x && direction.Equals (Vector3.right)) || (transform.position.x - width*0.5f < -edge.x && direction.Equals (Vector3.left))) {
			ReverseDirection ();
		}
		transform.position += direction * fleetSpeed * Time.deltaTime;
	}

	void ReverseDirection(){
		if (direction.Equals (Vector3.left)) {
			direction = Vector3.right;
		} else {
			direction = Vector3.left;
		}
	}
}

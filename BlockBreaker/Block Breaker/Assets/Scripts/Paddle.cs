using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

	public bool testMode = false;

	private Ball ball;

	void Start(){
		ball = GameObject.FindObjectOfType<Ball> ();
	}

	void Update () {
		if (testMode) {
			MoveWithBall ();
		} else {
			MoveWithMouse ();
		}
	}

	void MoveWithBall(){
		this.transform.position = new Vector3 (ball.transform.position.x, this.transform.position.y, this.transform.position.z);
	}

	void MoveWithMouse(){
		float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;
		this.transform.position = new Vector3 (Mathf.Clamp(mousePosInBlocks, 0.5f, 15.5f), this.transform.position.y, this.transform.position.z);
	}

	void OnCollisionEnter2D(Collision2D collision){
//		GetComponent<AudioSource> ().Play ();
	}
}

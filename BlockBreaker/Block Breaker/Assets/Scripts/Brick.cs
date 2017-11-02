using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

	public Sprite[] sprites;
	public AudioClip crack;
	public GameObject smoke;

	private int timesHit;
	private LevelManager levelManager;
	private bool isBreakable;

	public static int breakableCount = 0;

	// Use this for initialization
	void Start () {
		timesHit = 0;
		levelManager = GameObject.FindObjectOfType<LevelManager> ();

		isBreakable = this.tag == "Breakable";
		if (isBreakable) {
			breakableCount++;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D collision){
//		AudioSource.PlayClipAtPoint (crack, transform.position);
		if (isBreakable) {
			HandleHits ();
		}
	}

	void HandleHits(){
		timesHit++;
		if (timesHit > sprites.Length) {
			breakableCount--;
			SmokePuff ();
			DestroyBrick ();
		} 
		else {
			LoadSprites ();
		}
	}

	void SmokePuff(){
		GameObject smokePuff = Instantiate(smoke, gameObject.transform.position, Quaternion.identity);
		var main = smokePuff.GetComponent<ParticleSystem> ().main;
		main.startColor = gameObject.GetComponent<SpriteRenderer> ().color;
	}

	void DestroyBrick(){
		Destroy (gameObject);
	}

	void LoadSprites(){
		if (sprites [timesHit - 1]) {
			this.GetComponent<SpriteRenderer> ().sprite = sprites [timesHit - 1];
		} else {
			Debug.LogError ("Sprite " + (timesHit - 1) + " Missing");
		}
	}

	//TODO make this real
	void SimulateWin(){
		levelManager.LoadNextLevel();
	}
}

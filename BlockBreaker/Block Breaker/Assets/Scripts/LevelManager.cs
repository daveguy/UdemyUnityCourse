using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public void loadLevel(string level){
		Brick.breakableCount = 0;
		SceneManager.LoadScene (level);
	}

	public void LoadNextLevel(){
		Brick.breakableCount = 0;
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	public void quit(){
//		Debug.Log ("quit requested");
		Application.Quit ();
	}

	public void BrickDestroyed(){
		if(Brick.breakableCount <= 0){
			LoadNextLevel();
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public void loadLevel(string level){
		Debug.Log ("level Load requested" + level);
		SceneManager.LoadScene (level);
	}

	public void quit(){
		Debug.Log ("quit requested");
		Application.Quit ();
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	public Text guessText;

	private int guess;
	private int min;
	private int max;

	// Use this for initialization
	void Start () {
		guess = 500;
		min = 1;
		max = 1000;
		guessText.text = guess.ToString();
	}

	public void higher(){
		min = guess + 1;
		guess = (min + max ) / 2;
		updateText ();
	}

	public void lower(){
		max = guess - 1;
		guess = (min + max + 1) / 2;
		updateText ();
	}

	void updateText (){
		guessText.text = guess.ToString();
	}

}

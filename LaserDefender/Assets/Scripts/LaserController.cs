using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LaserType {PLAYER, ENEMY};

public class LaserController : MonoBehaviour {

	public int damage;

//	enum Type {PLAYER, ENEMY};
	private LaserType type;

	public int getDamage(){
		return damage;
	}

	public void Destroy(){
		Destroy (gameObject);
	}

	public void setType(LaserType type){
		this.type = type;
	}

	public LaserType getType(){
		return type;
	}
}

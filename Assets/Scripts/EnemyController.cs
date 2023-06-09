﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	public GameObject enemyBullet;
	public GameObject destroyedParticles;

	int health=200;
	// Use this for initialization
	void Start () {
		InvokeRepeating ("fireBullet", -.2f, .1f);
	}
	
	// Update is called once per frame
	void Update () {
		//Instantiate (enemyBullet, this.transform.position, Quaternion.identity);
		//if(Input.GetKeyDown(KeyCode.Space)){
			//fireBullet();
		//}

	}


	void fireBullet(){
		int randomNumber = Random.Range (0, 2);
		if (randomNumber == 0) {
			Vector3 startPos = this.transform.position + new Vector3 (0, -.5f, 0);
			Instantiate (enemyBullet, startPos, Quaternion.identity);
		}
	}

	void OnCollisionEnter2D (Collision2D col)
	{
		Debug.Log ("Collided" + col.gameObject.tag);
		if (col.gameObject.tag == "playerBullet") {
			health = health - 10;
			Destroy (col.gameObject);
			if (health < 10) {
				Instantiate (destroyedParticles, this.transform.position, Quaternion.identity);
				Destroy (gameObject);
			}
				
		}
	}

}

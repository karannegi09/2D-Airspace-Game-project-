using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	float speed =5f;
	public GameObject PlayerBullet;
	public GameObject destroyedParticles;

	int health=100;
	// Use this for initialization
	void Start () {
		InvokeRepeating ("fireBullet", .1f, .2f);
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButton (0)) {
			if (Input.mousePosition.x < Screen.width / 2) {
				this.transform.position += new Vector3 (-speed * Time.deltaTime, 0f, 0f);
			}
			if (Input.mousePosition.x > Screen.width / 2) {
				this.transform.position += new Vector3 (speed * Time.deltaTime, 0f, 0f);
			}
		}
		if (Input.GetKey (KeyCode.LeftArrow)) {
			this.transform.position += new Vector3 (-speed * Time.deltaTime, 0f, 0f);
		}

		if (Input.GetKey (KeyCode.RightArrow)) {
			this.transform.position += new Vector3 (speed * Time.deltaTime, 0f, 0f);
		}
		if (Input.GetKeyDown (KeyCode.Space)) {
			InvokeRepeating ("fireBullet", .1f, .2f);
		}
		if (Input.GetKeyUp (KeyCode.Space)) {
			CancelInvoke ("fireBullet");

		}
}

	void fireBullet(){
		Vector3 startPos=this.transform.position+new Vector3(0,1f,0);
		Instantiate (PlayerBullet, startPos,Quaternion.identity);

	}

	void OnCollisionEnter2D (Collision2D col)
	{
		Debug.Log ("Collided" + col.gameObject.tag);
		if (col.gameObject.tag == "enemyBullet") {
			health = health - 10;
			Destroy (col.gameObject);
			if (health < 10) {
				Instantiate (destroyedParticles, this.transform.position, Quaternion.identity);
				Destroy (gameObject);
			}
}
	}
}

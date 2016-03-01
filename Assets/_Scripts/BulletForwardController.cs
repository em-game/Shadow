/*
Source file name : BulletForwardController.cs
Author : Eunmi Han(300790610)
Date last Modified : Feb 29, 2016
Program Description : control bullet moving and score
Revision History : 1.01 - Initial Setup
                   1.02 - Add collision
                   1.03 - Add scoring
                   1.04 - Add animation
Last Modified by Eunmi Han
*/

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BulletForwardController : MonoBehaviour {

	//Public instance variables
	public float speed=300f;
	public GameObject Explosion;

	GameObject scoreUI;

	// Use this for initialization
	void Start () {
		
		scoreUI = GameObject.FindWithTag ("Score");
		scoreUI.GetComponent<GameController> ().BulletValue--;
	}
	
	// Update is called once per frame
	void Update () {


			//Get the bullet's current position
			Vector2 position = transform.position;

			//computer the bullet's new position
			position = new Vector2(position.x + this.speed * Time.deltaTime, position.y);

			//update the bullet's position
			transform.position = position;

			Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1,1));

			if (transform.position.x > max.x) {
				Destroy (gameObject);
			}

	}

	void OnCollisionEnter2D(Collision2D other){

		if (other.gameObject.CompareTag ("Zombie")) {
			PlayExplosion ();
			scoreUI.GetComponent<GameController> ().ScoreValue += 80;
			Destroy (gameObject);
			Destroy (other.gameObject);
		}

		if (other.gameObject.CompareTag ("Bat")) {
			PlayExplosion ();
			scoreUI.GetComponent<GameController> ().ScoreValue += 100;
			Destroy (gameObject);
			Destroy (other.gameObject);
		}

		if (other.gameObject.CompareTag ("ground")){
			Destroy (gameObject);
		}

		if (other.gameObject.CompareTag ("Player")){
			Destroy (gameObject);
		}

		if (other.gameObject.CompareTag ("Light")){
			Destroy (gameObject);
		}

	}

	//To instantiate an explosion
	void PlayExplosion(){
		GameObject _explosion = (GameObject)Instantiate (Explosion);

		//set the position of the explosion
		_explosion.transform.position = transform.position;
	}


}

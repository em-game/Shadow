/*
Source file name : TileFallingController.cs
Author : Eunmi Han(300790610)
Date last Modified : Feb 29, 2016
Program Description : For tile falling control
Revision History : 1.01 - Initial Setup
                   1.02 - Add collision
                   1.03 - Add fall delay

Last Modified by Eunmi Han
*/
using UnityEngine;
using System.Collections;

public class TileFallingController : MonoBehaviour { 

	//Public instance variables
	public float fallDelay = 3f;


	//private instance variables
	private Rigidbody2D _rb2d;

	// Use this for initialization
	void Awake () {
		this._rb2d = gameObject.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void OnCollisionEnter2D (Collision2D other) {
		if (other.gameObject.CompareTag ("Player")) {
			Invoke ("Fall", fallDelay);
		}
	
	}

	void Fall(){
		_rb2d.isKinematic = false;
	}
}

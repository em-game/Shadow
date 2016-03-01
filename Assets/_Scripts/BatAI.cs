/*
Source file name : https://github.com/em-game/Shadow.git
Author : Eunmi Han(300790610)
Date last Modified : Feb 29, 2016
Program Description : 2D Platformer Game 
Revision History : 1.01 - Initial Setup
                   1.02 - Add collision
                   1.03 - Add AI
                   1.04 - Add scoreUI
                   
Last Modified by Eunmi Han
*/
using UnityEngine;
using System.Collections;

public class BatAI : MonoBehaviour {
	//public instance variables
	public float speed;
	public Transform groundCheck;

	GameObject scoreUI;

	//private instance variables
	private Animator _animator;
	private Rigidbody2D _rigidBody2d;
	private Transform _transform;
	private float _myWidth;
	private Vector3 currRot;
	private bool isGrounded;
	private bool isLeft;

	// Use this for initialization
	void Start () {
		this._transform = gameObject.GetComponent<Transform> ();
		this._animator = gameObject.GetComponent<Animator> ();
		this._rigidBody2d = gameObject.GetComponent<Rigidbody2D> ();
		this._myWidth = gameObject.GetComponent<SpriteRenderer> ().bounds.extents.x;
		this.isLeft = false;


		//get the score from TextUI
		scoreUI = GameObject.FindWithTag ("Score");
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector2 lineCastPos = this._transform.position - this._transform.right * _myWidth;

		isGrounded = Physics2D.Linecast (this._transform.position, this.groundCheck.position, 1 << LayerMask.NameToLayer ("Ground"));

		Vector2 myVel = this._rigidBody2d.velocity;

		//If there's no ground, turn around
		if (!isGrounded) {
			if (isLeft) {
				_flip ();
				isLeft = false;
			} else {
				_flip ();
				isLeft = true;
			}
		}

		if (isLeft) {			
			myVel.x = -speed;
		} else {
			myVel.x = speed;
		}

		this._rigidBody2d.velocity = myVel;	
	}

	private void _flip() {
		if (this.isLeft) {
			Vector3 currRot = this._transform.eulerAngles;
			currRot.y += 180;
			this._transform.eulerAngles = currRot;
		} else {
			Vector3 currRot = this._transform.eulerAngles;
			currRot.y -= 180;
			this._transform.eulerAngles = currRot;
		}


	}
}

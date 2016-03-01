/*
Source file name : https://github.com/em-game/Shadow.git
Author : Eunmi Han(300790610)
Date last Modified : Feb 29, 2016
Program Description : 2D Platformer Game 
Revision History : 1.01 - Initial Setup
                   1.02 - Make the image reset when it reach the end of camera
                   
Last Modified by Eunmi Han
*/
using UnityEngine;
using System.Collections;

public class StartController : MonoBehaviour {
	//public Instance Variables
	public float speed = 5f;

	//private Instance Variables
	private Transform _transform;
	private Vector2 _currentPositioin;



	// Use this for initialization
	void Start () {

		//Make a reference with the Transform Component
		this._transform = gameObject.GetComponent<Transform>();

		//Reset the background to the top
		this.Reset();
	
	}
	
	// Update is called once per frame
	void Update () {
		this._currentPositioin = this._transform.position;
		this._currentPositioin -= new Vector2 (this.speed, 0);
		this._transform.position = this._currentPositioin;

		if (this._currentPositioin.x <= -797) {
			this.Reset ();
		}
	
	}

	public void Reset()
	{
		this._transform.position = new Vector2 (797f,0);	
	}
}

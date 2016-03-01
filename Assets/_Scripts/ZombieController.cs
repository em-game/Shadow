/*
Source file name : ZombieAI
Author : Eunmi Han(300790610)
Date last Modified : Feb 29, 2016
Program Description : Set the position of zombie
Revision History : 1.01 - Initial Setup
                   1.02 - Set the position of Zombie
                   
Last Modified by Eunmi Han
*/
using UnityEngine;
using System.Collections;

public class ZombieController : MonoBehaviour {
	//public instance varibales
	public GameObject zombie;

	//private instance varibales
	private Transform _transform;
	private Vector2 _currentPosition;

	// Use this for initialization
	void Start () {
		this._transform = gameObject.GetComponent<Transform> ();


		Instantiate (this.zombie, new Vector2(this._transform.position.x, this._transform.position.y+60), Quaternion.identity);
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
	}

}

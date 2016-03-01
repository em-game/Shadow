/*
Source file name : https://github.com/em-game/Shadow.git
Author : Eunmi Han(300790610)
Date last Modified : Feb 29, 2016
Program Description : 2D Platformer Game 
Revision History : 1.01 - Initial Setup
                   1.02 - Add collision
                   
Last Modified by Eunmi Han
*/
using UnityEngine;
using System.Collections;

public class GroundControll : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D other){

		if (other.gameObject.CompareTag ("ground")) {
			Destroy (other.gameObject);
		}
	}
}

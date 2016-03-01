/*
Source file name : https://github.com/em-game/Shadow.git
Author : Eunmi Han(300790610)
Date last Modified : Feb 29, 2016
Program Description : 2D Platformer Game 
Revision History : 1.01 - Initial Setup
                   1.02 - Add spawn point
                   
Last Modified by Eunmi Han
*/
using UnityEngine;
using System.Collections;

public class LightController : MonoBehaviour {
	//public instance varibales
	public Transform[] lightSpawns;
	public GameObject light;


	// Use this for initialization
	void Start () {
		Spawn();
	}
	
	// Update is called once per frame
	void Spawn () {
		for (int i = 0; i < lightSpawns.Length; i++) {

			int lightFlip = Random.Range (0, 2);

			if (lightFlip > 0)
				Instantiate (light, lightSpawns [i].position, Quaternion.identity);
		}
	
	}
}

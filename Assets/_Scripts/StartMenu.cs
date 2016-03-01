/*
Source file name : StartMenu.cs
Author : Eunmi Han(300790610)
Date last Modified : Feb 29, 2016
Program Description : For the start menu 
Revision History : 1.01 - Initial Setup and add button to go game screen


Last Modified by Eunmi Han
*/
using UnityEngine;
using System.Collections;

public class StartMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void StartGame(){
		Application.LoadLevel (1);
	}
}

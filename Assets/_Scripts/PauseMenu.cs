/*
Source file name : https://github.com/em-game/Shadow.git
Author : Eunmi Han(300790610)
Date last Modified : Feb 29, 2016
Program Description : 2D Platformer Game 
Revision History : 1.01 - Initial Setup
                   1.02 - Add resume, start, quit and main menu button
                   
Last Modified by Eunmi Han
*/
using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {

	public GameObject PauseUI;

	private bool paused = false;

	void Start(){
		PauseUI.SetActive (false);
	}

	void Update(){
		if (Input.GetButtonDown ("Pause")) {
			this.paused = !paused;
		}

		if (this.paused) {
			PauseUI.SetActive (true);
			Time.timeScale = 0;
		}

		if (!this.paused) {
			PauseUI.SetActive (false);
			Time.timeScale = 1;
		}
	}


	public void Resume(){
		this.paused = false;
	}

	public void Restart(){
		Application.LoadLevel (Application.loadedLevel);
	}

	public void MainMenu(){
		Application.LoadLevel (0);
	}

	public void Quit(){
		Application.Quit ();
	}
}

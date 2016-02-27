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

/*
Source file name : GameController.cs
Author : Eunmi Han(300790610)
Date last Modified : Feb 29, 2016
Program Description : Manage score, live and ending screen 
Revision History : 1.01 - Initial Setup
                   1.02 - Add score and live
                   1.03 - Add bullet count
                   1.04 - Add Heath Panel
                   1.05 - Add won status
Last Modified by Eunmi Han
*/
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
	// PRIVATE INSTANCE VARIABLES
	private int _scoreValue;
	private int _livesValue;
	private int _bulletCount;
	private bool _won;


	// PUBLIC ACCESS METHODS
	public int ScoreValue {
		get {
			return this._scoreValue;
		}

		set {
			this._scoreValue = value;
			this.ScoreLabel.text = "Score: " + this._scoreValue;
		}
	}

	public int LivesValue {
		get {
			return this._livesValue;
		}

		set {
			this._livesValue = value;
			if (this._livesValue <= 0) {
				this._endGame ();
			} 
		}
	}

	public int BulletValue {
		get {
			return this._bulletCount;
		}

		set {
			this._bulletCount = value;
			this.BulletLabel.text = ": " + this._bulletCount;
		}
	}

	public bool GameWin {
		get {
			return this._won;
		}

		set {
			this._won = value;
			if (this._won) {
				this._endGame ();
			}
		}
	}
		
	// PUBLIC INSTANCE VARIABLES
	public Text ScoreLabel;
	public Text GameOverLabel;
	public Text HighScoreLabel;
	public Text BulletLabel;
	public Text EndLabel;
	public Text RespwanLabel;
	public Button RestartButton;
	public Image LightBullet;
	public HeroController hero;
	public Sprite[] HealthSprites;
	public Image HealthUI;

	// Use this for initialization
	void Start () {
		this._initialize ();

	}
	
	// Update is called once per frame
	void Update () {
		HealthUI.sprite = HealthSprites [this.LivesValue];
	}

	//PRIVATE METHODS ++++++++++++++++++

	//Initial Method
	private void _initialize() {
		this.ScoreValue = 0;
		this.LivesValue = 5;
		this.BulletValue = 3;
		this.GameOverLabel.gameObject.SetActive (false);
		this.HighScoreLabel.gameObject.SetActive (false);
		this.hero.gameObject.SetActive (true);
		this.RestartButton.gameObject.SetActive(false);
		this.BulletLabel.gameObject.SetActive(true);
		this.LightBullet.gameObject.SetActive (true);
		this.HealthUI.gameObject.SetActive (true);
		this.EndLabel.gameObject.SetActive (false);
		this.RespwanLabel.gameObject.SetActive (false);
			
	
	}

	private void _endGame() {
		this.HighScoreLabel.text = "High Score: " + this._scoreValue;

		this.HighScoreLabel.gameObject.SetActive (true);
		this.ScoreLabel.gameObject.SetActive (false);
		this.RestartButton.gameObject.SetActive (true);
		this.hero.gameObject.SetActive (false);
		this.BulletLabel.gameObject.SetActive(false);
		this.LightBullet.gameObject.SetActive (false);
		this.HealthUI.gameObject.SetActive (false);

		if (this._won) {
			this.EndLabel.gameObject.SetActive (true);
		} else {
			this.GameOverLabel.gameObject.SetActive (true);
		}
	}


	void offAlarm(){
		this.RespwanLabel.gameObject.SetActive (false);
	}
	// PUBLIC METHODS

	public void RestartButtonClick() {
		SceneManager.LoadScene (SceneManager.GetActiveScene().name);
	}

	public void RespwanAlarm(){
		this.RespwanLabel.gameObject.SetActive (true);
		Invoke ("offAlarm", 3f);
	}
}

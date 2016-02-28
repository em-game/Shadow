using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameScore : MonoBehaviour {

	Text scoreTextUI;

	private int _score;

	public int Score
	{
		get{
			return this._score;
		}
		set{
			this._score = value;
			UpdateScoreTextUI ();
		}
	}
	// Use this for initialization
	void Start () {
		scoreTextUI = GetComponent<Text> ();
	
	}
	
	// Update is called once per frame
	void UpdateScoreTextUI () {
		scoreTextUI.text = "Score: " + this._score;
	}
}

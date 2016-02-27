using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthStatus : MonoBehaviour {

	public Sprite[] HealthSprites;

	public Image HealthUI;

	public GameController gameController;

	// Use this for initialization
	void Start () {
		
	
	}
	
	// Update is called once per frame
	void Update () {
		HealthUI.sprite = HealthSprites[this.gameController.LivesValue];
	}
}

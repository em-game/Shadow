using UnityEngine;
using System.Collections;

public class test : MonoBehaviour {

	//Public instance variables
	public float speed=300f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//Get the bullet's current position
		Vector2 position = transform.position;

		//computer the bullet's new position
		position = new Vector2(position.x + this.speed * Time.deltaTime, position.y);

		//update the bullet's position
		transform.position = position;

		Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1,1));

		if (transform.position.x > max.x) {
			Destroy (gameObject);
		}
	}
}

using UnityEngine;
using System.Collections;

public class TileFallingController : MonoBehaviour { 

	//Public instance variables
	public float fallDelay = 3f;


	//private instance variables
	private Rigidbody2D _rb2d;

	// Use this for initialization
	void Awake () {
		this._rb2d = gameObject.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void OnCollisionEnter2D (Collision2D other) {
		if (other.gameObject.CompareTag ("Player")) {
			Invoke ("Fall", fallDelay);
		}
	
	}

	void Fall(){
		_rb2d.isKinematic = false;
	}
}

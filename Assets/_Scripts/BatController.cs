using UnityEngine;
using System.Collections;

public class BatController : MonoBehaviour {
	//public instance varibales
	public GameObject bat;

	//private instance varibales
	private Transform _transform;
	private Vector2 _currentPosition;

	// Use this for initialization
	void Start () {
		this._transform = gameObject.GetComponent<Transform> ();


		Instantiate (this.bat, new Vector2(this._transform.position.x, this._transform.position.y+60), Quaternion.identity);

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

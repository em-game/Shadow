using UnityEngine;
using System.Collections;

public class StartController : MonoBehaviour {
	//public Instance Variables
	public float speed = 5f;

	//private Instance Variables
	private Transform _transform;
	private Vector2 _currentPositioin;



	// Use this for initialization
	void Start () {

		//Make a reference with the Transform Component
		this._transform = gameObject.GetComponent<Transform>();

		//Reset the background to the top
		this.Reset();
	
	}
	
	// Update is called once per frame
	void Update () {
		this._currentPositioin = this._transform.position;
		this._currentPositioin -= new Vector2 (this.speed, 0);
		this._transform.position = this._currentPositioin;

		if (this._currentPositioin.x <= -797) {
			this.Reset ();
		}
	
	}

	public void Reset()
	{
		this._transform.position = new Vector2 (797f,0);	
	}
}

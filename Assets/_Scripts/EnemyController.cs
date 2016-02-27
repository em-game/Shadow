using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	public GameObject enemy;

	private Transform _transform;
	private Vector2 _currentPosition;



	// Use this for initialization
	void Start () {
		this._transform = gameObject.GetComponent<Transform> ();


		Instantiate (this.enemy, new Vector2(this._transform.position.x, this._transform.position.y+60), Quaternion.identity);
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
	}

}

using UnityEngine;
using System.Collections;

public class PlatformSpawn : MonoBehaviour {
	//Public Instance Variables
	public GameObject platform;
	public float horizontalMin = 7.5f;
	public float horizontalMax = 14f;
	public float verticalMin = -6f;
	public float verticalMax = 6f;

	//Private Instance Variables
	private Vector2 originPosition;

	// Use this for initialization
	void Start () {
		originPosition = transform.position;
		Spawn();
	
	}
	
	// Update is called once per frame
	void Spawn () {
		//Random platform
		for (int i = 0; i < 20; i++) {
			float xPosition = Random.Range (horizontalMin, horizontalMax);
			float yPosition = Random.Range (verticalMin, verticalMax); 

			Vector2 randomPosition = originPosition + new Vector2 (xPosition, yPosition);
			Instantiate (platform, randomPosition, Quaternion.identity);
			originPosition = randomPosition;
		}
	}
}

using UnityEngine;
using System.Collections;

public class LightController : MonoBehaviour {
	//public instance varibales
	public Transform[] lightSpawns;
	public GameObject light;


	// Use this for initialization
	void Start () {
		Spawn();
	}
	
	// Update is called once per frame
	void Spawn () {
		for (int i = 0; i < lightSpawns.Length; i++) {

			int lightFlip = Random.Range (0, 2);

			if (lightFlip > 0)
				Instantiate (light, lightSpawns [i].position, Quaternion.identity);
		}
	
	}
}

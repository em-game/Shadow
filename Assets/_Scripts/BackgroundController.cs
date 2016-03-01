/*
Source file name : https://github.com/em-game/Shadow.git
Author : Eunmi Han(300790610)
Date last Modified : Feb 29, 2016
Program Description : 2D Platformer Game 
Revision History : 1.01 - Initial Setup
                   1.02 - Set range of camera position to make repeat images

Last Modified by Eunmi Han
*/
using UnityEngine;
using System.Collections;

[RequireComponent (typeof(SpriteRenderer))]

public class BackgroundController : MonoBehaviour {

	// the offset so that we don't get any weird errors
	public int offsetX = 2;



	// these are userd for checking if we need to instantiate stuff
	public bool hasARightBubby = false;
	public bool hasALeftBuddy = false;

	//if the object is not tilable
	public bool reverseScale = false;

	private float spriteWidth =0f; // the width of our element
	private Camera cam;
	private Transform myTransform;
	private int minMap=0;

	void Awake(){
		cam = Camera.main;
		myTransform = transform;
	}

	// Use this for initialization
	void Start () {
		SpriteRenderer sRenderer= GetComponent<SpriteRenderer> ();
		spriteWidth = sRenderer.sprite.bounds.size.x;
	
	}
	
	// Update is called once per frame
	void Update () {
		
		// does it still nedd buddies? If not do nothing
		if (hasALeftBuddy == false || hasARightBubby == false) {
			
			// calculate the cameras extend (half the width) of what the camera can see in world coordinates
			float camHorizontalExtend = cam.orthographicSize * Screen.width / Screen.height;

			//calculate the x position where the camera can see the edge of the sprite element
			float edgeVisiblePositionRight = (myTransform.position.x + spriteWidth / 2) - camHorizontalExtend;
			float edgeVisiblePositionLeft = (myTransform.position.x - spriteWidth / 2) - camHorizontalExtend;


				// checking if ew can see the edge of the element and then calling MakeNewBuddy if we can
				if (cam.transform.position.x >= edgeVisiblePositionRight - offsetX && hasARightBubby == false) {
					MakeNewBuddy (1);
					hasALeftBuddy = true;


				} else if (cam.transform.position.x <= edgeVisiblePositionLeft + offsetX && hasALeftBuddy == false) {
					MakeNewBuddy (-1);
					hasALeftBuddy = true;

				}
				



		}

	}

	// A function that create a buddy on the side required
	void MakeNewBuddy(int rightOrLeft){

		if (minMap < 1) {
			//calculating the new position for our new Buddy
			Vector3 newPosition = new Vector3 (myTransform.position.x + spriteWidth * rightOrLeft,
				                     myTransform.position.y, myTransform.position.z);
			// instantating our new body and storing him in a variable
			Transform newBuddy = Instantiate (myTransform, newPosition, myTransform.rotation) as Transform;

			// if not tilable let's reverse the x size og our object to get rid of ugly seams
			if (reverseScale == true) {
				newBuddy.localScale = new Vector3 (newBuddy.localScale.x * -1, newBuddy.localScale.y, newBuddy.localScale.z);
			}

			newBuddy.parent = myTransform.parent;

			if (rightOrLeft > 0) {
				newBuddy.GetComponent<BackgroundController> ().hasALeftBuddy = true;
			} else {
				newBuddy.GetComponent<BackgroundController> ().hasARightBubby = true;
			}

			minMap++;
		}
	}
}

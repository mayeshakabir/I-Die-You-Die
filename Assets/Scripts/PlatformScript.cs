using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour {

	private float speed = 2f;

	// Use this for initialization
	void Start () {
		
	}


	void Update() {
		// Update is called once per frame
		//get the position
		Vector2 position = transform.position;

		//set new position to move right in x direction
		position = new Vector2 (position.x, position.y - speed * Time.deltaTime);

		//set new position
		transform.position = position;

		//destroy if off screen
		Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0));
		if (transform.position.y < min.y - 1f) {
			Destroy (gameObject);
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlatformsScript : MonoBehaviour {

	//public GameObject platformToSpawn;
	public GameObject[] platforms;
	float rate = 1f;

	// Use this for initialization
	void Start () {
		Invoke ("Spawn", rate);
	}

	// Update is called once per frame
	void Update () {

	}

	void Spawn() {



		GameObject platform = platforms[Random.Range(0, 3)];
		//top right
		Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2 (1,1));

		//bottom right
		Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2 (0,0));

		platform = (GameObject)Instantiate (platform);

		platform.transform.position = new Vector2 (Random.Range((min.x), (max.x)), Random.Range(max.y, max.y+3f));

		NextSpawn ();

	}

	void NextSpawn() {

		float newRate;

		if (rate > 0.3f) {
			newRate = Random.Range (0.3f, rate);
		} else
			newRate = 0.3f;

		Invoke("Spawn", newRate);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnScript : MonoBehaviour {

	public GameObject[] enemies;
	float rate = 1f;

	// Use this for initialization
	void Start () {
		Invoke ("Spawn", rate);
	}

	// Update is called once per frame
	void Update () {

	}

	void Spawn() {

		GameObject enemy = enemies[Random.Range(0, 2)];
		//top right
		Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2 (1,1));

		//bottom right
		Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2 (0,0));

		enemy = (GameObject)Instantiate (enemy);

		enemy.transform.position = new Vector2 (Random.Range((min.x), (max.x)), Random.Range(max.y, max.y+1f));

		NextSpawn ();

	}

	void NextSpawn() {

		float newRate;

		if (rate > 1f) {
			newRate = Random.Range (1f, rate);
		} else
			newRate = 1f;

		Invoke("Spawn", newRate);
	}
}

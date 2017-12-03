using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{

	float speed = 3f;
	bool isJumping;
	Vector3 toLerp;
	float JumpTop = 3f;
	private float health = 2;
	public Text LivesText;
	public int player;
	//private bool isDead = false;

	// Use this for initialization
	void Start () {
		LivesText.text = health.ToString ();
	}

	// Update is called once per frame
	void Update () {
		if (GameManager.instance.isDead == true) {
			var gameOver = FindObjectOfType<GameOverScript>();
			gameOver.ShowButtons();
			Destroy (gameObject);
		}
			JumpFunction ();

			if (player == 1) {

				if (Input.GetKey (KeyCode.LeftArrow)) {
					transform.eulerAngles = new Vector2 (0, 180);
					transform.Translate (Vector2.right * speed * Time.deltaTime);
				}
				if (Input.GetKey (KeyCode.RightArrow)) {
					transform.eulerAngles = new Vector2 (0, 0);
					transform.Translate (Vector2.right * speed * Time.deltaTime);
				}
			}

			if (player == 2) {

				if (Input.GetKey (KeyCode.A)) {
					transform.eulerAngles = new Vector2 (0, 180);
					transform.Translate (Vector2.right * speed * Time.deltaTime);
				}
				if (Input.GetKey (KeyCode.D)) {
					transform.eulerAngles = new Vector2 (0, 0);
					transform.Translate (Vector2.right * speed * Time.deltaTime);
				}
			}

		Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0));
		if (transform.position.y < (min.y - 1f)) {
			GameManager.instance.isDead = true;
		}

		/*
		//getting position with which button
		//returns -1 - 1, on which pos/neg button you press
		float xAxis = Input.GetAxis("Horizontal");

		//Movement with what button direction * speed I want * Time.deltaTime to make it run per second
		Vector2 movement = new Vector2(xAxis, 0) * speed * Time.deltaTime;

		//the movement
		transform.Translate (movement);

		//bounds

		var dist = (transform.position - Camera.main.transform.position).z;

		var left = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).x;
		var right = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, dist)).x;
		var top = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).y;
		var bottom = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, dist)).y;

		transform.position = new Vector3(
			Mathf.Clamp(transform.position.x, left, right),
			Mathf.Clamp(transform.position.y, top, bottom),
			transform.position.z);
		*/
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.tag == "enemyTag") {
			health--;
			LivesText.text = health.ToString ();
			if (health == 0) {
				GameManager.instance.isDead = true;
			}
		}

		if (col.tag == "platformTag") {
			isJumping = true;
			gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
			gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
		}
	}

	void JumpFunction(){
		toLerp = new Vector3 (transform.position.x, JumpTop, -0.5f);
		if (isJumping == true && transform.position.y < JumpTop - 0.5f) {
			transform.position = Vector3.Lerp (transform.position, toLerp, 3 * Time.deltaTime);
		} else {
			isJumping = false;
			gameObject.GetComponent<Rigidbody2D> ().gravityScale = 1;

		}
	}
}
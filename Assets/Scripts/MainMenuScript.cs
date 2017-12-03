using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuScript : MonoBehaviour {

	public void StartGame() {

		// if pressed start button change to game scene
		Application.LoadLevel("Scene1");
	}
}

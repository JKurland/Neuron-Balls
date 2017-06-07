using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour {
	public GameObject gameOverText;
	public GameObject finalScore;
	public GameObject restartText;

	public bool running = true;
	// Use this for initialization
	void Start () {
		gameOverText.GetComponent<Text> ().enabled = false;
		finalScore.GetComponent<Text> ().enabled = false;
		restartText.GetComponent<Text>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (running == false) {
			if (Input.GetKeyDown (KeyCode.R)) {
				Debug.Log ("Restarting");
				SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
			}
		}
	}

	public void gameOver(int score){
		gameOverText.GetComponent<Text> ().enabled = true;

		finalScore.GetComponent<Text> ().text = string.Format ("Final Score: {0}", score);
		finalScore.GetComponent<Text> ().enabled = true;

		restartText.GetComponent<Text>().enabled = true;

		running = false;
	}



}

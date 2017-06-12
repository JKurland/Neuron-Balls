using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LossTrigger : MonoBehaviour {
	int count = 0;
	int score = 0;
	int life = 3;
	public GameObject gameController;
	public GameObject spawner;
	GameObject scoreText;
	public GameObject[] lives;


	Controller controller;
	// Use this for initialization
	void Start () {
		controller = gameController.GetComponent<Controller> ();
		scoreText = GameObject.Find ("Score");
		scoreText.GetComponent<Text> ().text = score.ToString ();
	}
	
	// Update is called once per frame
	void Update () {
		controller.sendScore (score);

	}

	public void DisplayScore(){
		score = spawner.GetComponent<Spawner>().total_spawned - count;
		scoreText.GetComponent<Text> ().text = score.ToString ();
	}

	void OnTriggerEnter(Collider other){
		if (other.name == "Sphere" && controller.running) {
			count++;
			life--;

			score = spawner.GetComponent<Spawner>().total_spawned - count;
			scoreText.GetComponent<Text> ().text = score.ToString ();
			Debug.Log (life);
			Destroy (lives [life]);

			if (life == 0) {
				controller.gameOver (score);
			}
		}
	}
}

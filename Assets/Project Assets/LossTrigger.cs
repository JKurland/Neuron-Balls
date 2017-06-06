using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LossTrigger : MonoBehaviour {
	int count = 0;
	int score = 0;
	int life = 3;
	public GameObject spawner;
	GameObject scoreText;
	GameObject[] lives;

	// Use this for initialization
	void Start () {
		scoreText = GameObject.Find ("Score");
		lives[0] = GameObject.Find ("Life1");
		lives[1] = GameObject.Find ("Life2");
		lives[2] = GameObject.Find ("Life3");
		scoreText.GetComponent<Text> ().text = score.ToString ();
	}
	
	// Update is called once per frame
	void Update () {
		score = spawner.GetComponent<Spawner>().total_spawned - count;
		scoreText.GetComponent<Text> ().text = score.ToString ();

	}

	void OnTriggerEnter(Collider other){
		Debug.Log (other.name);
		if (other.name == "Sphere") {
			count++;
			life--;
			Destroy (lives [life]);
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class countdown : MonoBehaviour {
	public int length;
	int current;
	float time = 0f;
	// Use this for initialization
	void Start () {
		current = length;
		gameObject.GetComponent<Text> ().text = length.ToString ();

	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;

		if (time > 1) {
			time = 0f;
			current -= 1;

			if (current < 0) {
				Destroy (gameObject);
				return;
			}

			gameObject.GetComponent<Text> ().text = current.ToString ();
		}


	}
}

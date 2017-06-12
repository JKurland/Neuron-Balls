using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour {
	float maxAcceleration;

	Vector3 target = Vector3.zero;

	bool move;
	bool moving;


	float timeRemaining;
	float speed = 0;
	float maxSpeed;
	float timeElapsed;
	float[] marks = {0,0,0};

	int state;

	// Use this for initialization
	void Start () {
		target = gameObject.transform.position;
	}

	
	// Update is called once per frame
	void Update () {
		timeRemaining -= Time.deltaTime;
		timeElapsed += Time.deltaTime;
		transitionState ();


		switch (state){
		case 0:
			speed += maxAcceleration * Time.deltaTime;
			break;
		case 2:
			speed -= maxAcceleration * Time.deltaTime;
			break;
		}

		float step = speed * Time.deltaTime;

		gameObject.transform.position = Vector3.MoveTowards (gameObject.transform.position, target, step);

	}

	public void moveTo(Vector3 newTarget, float totalTime){
		target = newTarget;
		speed = 0;
		float time = totalTime * 0.9f;
		float distance = (gameObject.transform.position - target).magnitude;
		timeRemaining = time;
		maxAcceleration = 4 * distance / time / time;
		maxSpeed = maxAcceleration * time / 2;

		marks [0] = maxSpeed / maxAcceleration;
		marks [1] = time - maxSpeed / maxAcceleration;
		marks [2] = time;

		timeElapsed = 0f;
		state = 0;
	}

	void transitionState(){
		
		switch (state) {
		case 0:
			if (timeElapsed >= marks [0]) {
				state = 1;
			}
			break;
		case 1:
			if (timeElapsed >= marks [1]) {
				state = 2;
			}
			break;
		case 2:
			if (timeElapsed >= marks [2]) {
				state = 3;
			}
			break;
		}

	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuicideTrigger : MonoBehaviour {
	private float lifetime = 2f;
	GameObject backTrigger;
	bool dying = false;
	// Use this for initialization
	void Start () {
		backTrigger = GameObject.Find ("BackTrigger");
	}
	
	// Update is called once per frame
	void Update () {
		if (dying) {
			lifetime -= Time.deltaTime;
		}

		if (lifetime < 0) {
			Destroy (transform.parent.gameObject);
		}
	}

	void OnTriggerEnter(Collider other){
		if (other.name == "BackTrigger") {
			dying = true;
		}
	}

	void OnCollisionEnter(Collision other){
		
		if (other.collider.name.Contains("Collider")){
			Debug.Log (other.collider.name);
			backTrigger.GetComponent<LossTrigger>().DisplayScore();
		}
	}
		
}
	
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour {
	AudioSource[] audios;
	AudioSource shot;
	AudioSource thud;
	// Use this for initialization
	void Start () {
		shot = audios [0];
		thud = audios [1];
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collider other){
		Debug.Log ("collide");
		if (other.name == "Floor") {
			thud.Play ();
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour {
	
	AudioSource shot;
	AudioSource thud;
	// Use this for initialization
	void Start () {
		AudioSource[] audios = GetComponents<AudioSource> ();
		shot = audios [0];
		thud = audios [1];
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision other){
		Debug.Log (other.gameObject.name);
		if (other.gameObject.name == "Floor") {
			thud.Play ();
		}

	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour {
	
	AudioSource shot;
	AudioSource[] playerThuds;
	AudioSource[] groundThuds;

	int groundCollisions = 0;

	// Use this for initialization
	void Start () {
		AudioSource[] audios = GetComponents<AudioSource> ();
		shot = audios [0];
		playerThuds = slice (audios, 1, 3);
		groundThuds = slice (audios, 3, -1);
		Random.InitState (Time.frameCount);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision other){
		

		if (other.gameObject.name == "Floor") {
			double pitchShift = 0.2*(Random.value - 0.5) + 1f;
			int skip = Random.Range (0, 2);

			groundThuds [groundCollisions + skip].pitch = (float)pitchShift;
			groundThuds[groundCollisions + skip].Play ();
			groundCollisions += 1;
			if ( groundCollisions >= groundThuds.Length - 1){
				groundCollisions = groundThuds.Length - 2;
			}
		}

		if (other.gameObject.name == "ColliderR" || other.gameObject.name == "ColliderL") {
			double pitchShift = 0.2*(Random.value - 0.5) + 1f;

			int r = Random.Range (0, playerThuds.Length);
			playerThuds [r].volume = other.impulse.magnitude/2;
			playerThuds [r].pitch = (float)pitchShift;
			playerThuds [r].Play ();
		}

	}
		
	public static T[] slice<T>(T[] l, int from, int to)
	{
		if (to == -1) {
			to = l.Length;
		}

		T[] r = new T[to - from];
		for (int i = from; i < to; i++)
		{
			r[i-from]=l[i];
		}
		return r;
	}
}

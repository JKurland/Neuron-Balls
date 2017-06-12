using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour {
	public GameObject gameOverText;
	public GameObject finalScore;
	public GameObject restartText;
	public GameObject highscoreText;

	public GameObject spawner;
	public GameObject barrel;
	public GameObject cannon;

	public bool running = true;

	int score;

	class Tuple<T1, T2>{
		public T1 First{ get; private set; }
		public T2 Second{ get; private set; }

		internal Tuple(T1 first, T2 second){
			First = first;
			Second = second;
		}



	}
	// Use this for initialization
	void Start () {
		gameOverText.GetComponent<Text> ().enabled = false;
		finalScore.GetComponent<Text> ().enabled = false;
		highscoreText.GetComponent<Text> ().enabled = false;
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

		if ((Input.GetKey (KeyCode.RightControl) || Input.GetKey (KeyCode.LeftControl)) && Input.GetKeyDown (KeyCode.H)) {
			PlayerPrefs.SetInt ("highscore", 0);
		}
			
	}

	public void gameOver(int score){
		var highscore = StoreHighscore (score);

		gameOverText.GetComponent<Text> ().enabled = true;

		finalScore.GetComponent<Text> ().text = string.Format ("Final Score: {0}", score);
		finalScore.GetComponent<Text> ().enabled = true;

		if (highscore.Second){
			highscoreText.GetComponent<Text> ().text = string.Format ("New Highscore!!!");
			highscoreText.GetComponent<Text> ().color = new Color (238/255f, 129/255f, 70/255f, 255/255f);

		}else{
			highscoreText.GetComponent<Text> ().text = string.Format ("Highscore: {0}", highscore.First);
			highscoreText.GetComponent<Text> ().color = new Color(50/255f,50/255f,50/255f,255/255f);

		}

		highscoreText.GetComponent<Text> ().enabled = true;

		restartText.GetComponent<Text>().enabled = true;

		running = false;
	}

	public void sendScore(int newScore){
		score = newScore;
	}

	Tuple<int, bool> StoreHighscore(int newHighscore)
	{
		bool change = false;
		int oldHighscore = PlayerPrefs.GetInt("highscore", 0);   

		if (newHighscore > oldHighscore) {
			PlayerPrefs.SetInt ("highscore", newHighscore);
			oldHighscore = newHighscore;
			change = true;
		}

		var rtn = new Tuple<int, bool> (max(oldHighscore, newHighscore), change);
		return rtn;
	}

	T max<T>(T x, T y){
		return (Comparer<T>.Default.Compare(x, y) > 0) ? x : y;
	}
}

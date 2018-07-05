using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour {

	public static int scoreValue=0;
	public static int topScoreValue=0;
	public static int gameCountValue=0;

	public Text score;
	public Text topScore;
	public Text gameCount;

	// Use this for initialization
	void Start () {
//		PlayerPrefs.DeleteAll ();
		scoreValue = 0;

			gameCountValue = PlayerPrefs.GetInt ("GamePlayed");
			gameCountValue += 1;
			PlayerPrefs.SetInt ("GamePlayed", gameCountValue);
			PlayerPrefs.Save ();

		score = score.GetComponent<Text> ();
		topScore = topScore.GetComponent<Text> ();
		gameCount = gameCount.GetComponent<Text> ();

		gameCount.text = "GAMES PLAYED: " + gameCountValue;
	}
	
	// Update is called once per frame
	void Update () {
		score.text = "" + scoreValue;

			topScoreValue = PlayerPrefs.GetInt ("BestScore");

		if (scoreValue > topScoreValue) {
				topScore.text = "BEST SCORE: " + scoreValue;
				PlayerPrefs.SetInt ("BestScore", scoreValue);
				print (scoreValue);
				PlayerPrefs.Save ();
			}
		topScoreValue = PlayerPrefs.GetInt ("BestScore");
		topScore.text = "BEST SCORE: " + topScoreValue;
	}
}

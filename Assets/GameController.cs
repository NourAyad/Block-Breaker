using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    private int score;
    public Text scoreText;

	// Use this for initialization
	void Start () {
        score = 0;
        UpdateScore();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }
}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[System.Serializable]
public class Materials
{
    public Material mat1, mat2, mat3;
}

public class GameController : MonoBehaviour {

    private int score;
    public Text scoreText;
    public Text gameOverText;
    public Text livesText;
    public int lives;
    private int health;
    public Materials materials;
    public bool gameOver;
    public bool reset;
    public BallController ballController;

	// Use this for initialization
	void Start () {
        gameOver = false;
        reset = false;
        gameOverText.text = "";
        health = lives;
        score = 0;
        UpdateText();

	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateText();
       // Reset();
    }

    void UpdateText()
    {
        scoreText.text = "Score: " + score;
        livesText.text = "Lives: " + health;
    }

    public void LoseLife()
    {
        health -= 1;
        if (health <= 0)
        {
            GameOver();
        } else {
            Reset();
        }
        UpdateText();
    }

    void GameOver()
    {
        gameOver = true;
        Reset();
        gameOverText.text = "Game Over!";
    }

    void Reset()
    {
        reset = true;
        ballController.released = false;
        ballController.neverReleased = true;
    }

}

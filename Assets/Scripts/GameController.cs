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
    public int winScore;
    public GameObject blocks;
    private BlockDestroyer[] gameBlocks;

	// Use this for initialization
	void Start () {
        Screen.SetResolution(730, 900, false);
        gameBlocks = blocks.GetComponentsInChildren<BlockDestroyer>();
        gameOver = false;
        reset = false;
        gameOverText.text = "";
        health = lives;
        score = 0;
        winScore = 0;
        UpdateText();
        CountScore();
	}
	
	// Update is called once per frame
	void Update () {
	    if (score >= winScore)
        {
            Win();
        }
	}

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateText();
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

    void Win()
    {
        gameOver = true;
        Reset();
        gameOverText.text = "You Win!";
    }

    void Reset()
    {
        reset = true;
        ballController.released = false;
        ballController.neverReleased = true;
    }

    void CountScore()
    {
        foreach (BlockDestroyer t in gameBlocks)
        {
            winScore += ((t.blockLives - 1) * t.hitScore + t.destroyScore);
            Debug.Log(winScore);
        }
    }

}

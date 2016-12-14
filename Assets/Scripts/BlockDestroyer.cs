using UnityEngine;
using System.Collections;

public class BlockDestroyer : MonoBehaviour {

    public GameController gameController;
    public int blockLives;
    private int blockHealth;
    public int destroyScore;
    public int hitScore;
    

	// Use this for initialization
	void Start () {

        blockHealth = blockLives;
	}
	
	// Update is called once per frame
	void Update () {
	    if (blockHealth == 0)
        {
            Destroy(gameObject);
        }
	}

    void OnCollisionEnter (Collision other)
    {
        //if (other.tag == "GameBall")
        {
            //Damage(other.GetComponent<BallController>().damage);
            Damage(1);
            Debug.Log("damaged" + blockHealth);
        }
    }

    void Damage (int dmg)
    {
        blockHealth -= dmg;
        gameController.AddScore(hitScore);
    }
}

using UnityEngine;
using System.Collections;

public class BlockDestroyer : MonoBehaviour {

    public GameController gameController;
    public int blockLives;
    private int blockHealth;
    public int destroyScore;
    public int hitScore;
    private bool destroyed;
    private MeshRenderer renderer;
    

	// Use this for initialization
	void Start () {
        renderer = GetComponent<MeshRenderer>();
        blockHealth = blockLives;
        destroyed = false;
	}
	
	// Update is called once per frame
	void Update () {
	    if (blockHealth == 0 && !destroyed)
        {
            gameController.AddScore(destroyScore - hitScore);
            Hide();
            destroyed = true;
        }

        if (gameController.reset == true)
        {
            Reset();
            gameController.reset = false;
        }
	}

    void OnCollisionEnter (Collision other)
    {
        //if (other.gameObject.tag == "GameBall")
        {
            Damage(other.gameObject.GetComponent<BallController>().damage);
            renderer.material = gameController.materials.mat2;
            Debug.Log("damaged" + blockHealth);
        }
    }

    void Damage (int dmg)
    {
        blockHealth -= dmg;
        gameController.AddScore(hitScore);
    }

    void Reset()
    {
        //Show();
        blockHealth = blockLives;
        destroyed = false;
    }

    void Hide()
    {
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        this.gameObject.GetComponent<MeshRenderer>().enabled = false;
    }

    void Show()
    {
        this.gameObject.GetComponent<BoxCollider>().enabled = true;
        this.gameObject.GetComponent<MeshRenderer>().enabled = true;
    }
}

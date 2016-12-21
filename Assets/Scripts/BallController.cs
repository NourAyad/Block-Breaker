using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour
{

    public Transform StartPoint;
    private Transform ballTransform;
    private Rigidbody ballRigidBody;
    public float speed;
    public int damage;
    public GameController gameController;

    private Vector3 currentVelocity;

    public bool released;
    public bool neverReleased;
    private Random random;
    private int direction;

	void Start ()
    {
        ballTransform = GetComponent<Transform>();
        ballRigidBody = GetComponent<Rigidbody>();
        ballTransform.position = StartPoint.position;
        released = false;
        neverReleased = true;
        
	}
	
    void Update ()
    {
        if (Input.GetButton("Release"))
        {
            released = true;
        }
    }
	
	void FixedUpdate ()
    {
        currentVelocity = ballRigidBody.velocity;
        if (!released) {
            ballTransform.position = StartPoint.position;
        } else if (released && neverReleased && !gameController.gameOver) {
            //ballRigidBody.AddForce(0, 0, 100 * speed);
            ballRigidBody.velocity = new Vector3(Random.Range(-1.0f, 1.0f) * speed, 0, 1 * speed);
            currentVelocity = ballRigidBody.velocity;
            Debug.Log(currentVelocity.x);
            neverReleased = false;
        }
        if (ballRigidBody.velocity.z >= 0)
        {
            direction = 1;
        } else
        {
            direction = -1;
        }
        ballRigidBody.velocity = new Vector3(ballRigidBody.velocity.x, ballRigidBody.velocity.y, direction * Mathf.Clamp(ballRigidBody.velocity.z, speed - 2, speed + 2));

        
	}

    void OnTriggerEnter (Collider other)
    {
        if(other.CompareTag("Player") && released)
        {
            ballRigidBody.velocity = new Vector3(currentVelocity.x, currentVelocity.y, currentVelocity.z * -1);
        }
                
    }

    void OnCollisionEnter (Collision other)
    {
        if (other.gameObject.CompareTag("BackWall") /*&& released */)
        {
            gameController.LoseLife();
            Debug.Log("hit");
        }
    }
}

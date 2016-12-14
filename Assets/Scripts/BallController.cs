using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour
{

    public Transform StartPoint;
    private Transform ballTransform;
    private Rigidbody ballRigidBody;
    public float speed;
    public int damage;

    private Vector3 currentVelocity;

    private bool released;
    private bool neverReleased;
    private Random random;

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
        } else if (released && neverReleased) {
            //ballRigidBody.AddForce(0, 0, 100 * speed);
            ballRigidBody.velocity = new Vector3(Random.Range(-1.0f, 1.0f) * speed, 0, 1 * speed);
            currentVelocity = ballRigidBody.velocity;
            Debug.Log(currentVelocity.x);
            neverReleased = false;
        }

        
	}

    void OnTriggerEnter (Collider other)
    {
        if(other.tag == "Player" && released)
        {
            ballRigidBody.velocity = new Vector3(currentVelocity.x, currentVelocity.y, currentVelocity.z * -1);
        }
    }
}

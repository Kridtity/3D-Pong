using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float _XForce = 30f;
    public float _ZForce = 30f;
    public float speed = 20f;
    public float _waitTime = 3f;
    Vector3 vel;


    private Rigidbody rb;

    void BallStart()
    {
        float _randomSide = Random.Range(0, 2);

        if (_randomSide >= 1)
        {
            rb.AddForce((_XForce * speed), 0, (_ZForce * speed));
        }
        else
        {
            rb.AddForce((-_XForce * speed), 0 , (_ZForce * speed));
        }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Invoke("BallStart", _waitTime);        
    }

    void BallReset()
    {
        rb.velocity = Vector3.zero;
        transform.position = new Vector3(0, 1, 0);
    }

    void GameReset()
    {
        BallReset();
        Invoke("BallStart", _waitTime);
    }

    void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.CompareTag("Player"))
        {
            vel.x = rb.velocity.x;
            vel.z = (rb.velocity.z / 2) + (coll.collider.attachedRigidbody.velocity.z / 3);

            rb.velocity = vel;            
        }

    }
}
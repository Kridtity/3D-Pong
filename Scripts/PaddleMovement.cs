using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
    #region Variables
    [Header("Movement")]
    public KeyCode _Up = KeyCode.UpArrow;
    public KeyCode _Down = KeyCode.DownArrow;
    public KeyCode _Left = KeyCode.LeftArrow;
    public KeyCode _Right = KeyCode.RightArrow;
    public float _speed = 10f;

    [Space]
    [Header("Constraints")]

    public float _boundRXOuter = 13.45f;
    public float _boundRXInner = 3f;
    public float _boundLXOuter = -13.45f;
    public float _boundLXInner = -3f;

    public float _boundZ = 4.75f;

    private Rigidbody rb;
    #endregion

    void Start()
    {
        Debug.Log("Program start.");
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //Move z script
        var vel = rb.velocity * Time.fixedDeltaTime;

        if (Input.GetKey(_Up))
        {
            vel.z = _speed;
        } 
        else if (Input.GetKey(_Down))
        {
            vel.z = -_speed;
        }
        else
        {
            vel.z = 0;
        }

        //Move x script
        if (Input.GetKey(_Right))
        {
            vel.x = _speed;
        }
        else if (Input.GetKey(_Left))
        {
            vel.x = -_speed;
        }
        else
        {
            vel.x = 0;
        }
        rb.velocity = vel;


        //Move z constraints
        var _pos = transform.position;

        if (_pos.z >= _boundZ)
        {
            _pos.z = _boundZ;
        }
        else if (_pos.z <= -_boundZ)
        {
            _pos.z = -_boundZ;
        }

        //Move x constraints
        if (gameObject.CompareTag("RightPaddle"))
        {
            if (_pos.x >= _boundRXOuter)
            {
                _pos.x = _boundRXOuter;
            }
            else if (_pos.x <= _boundRXInner)
            {
                _pos.x = _boundRXInner;
            }
        }
        else if (gameObject.CompareTag("LeftPaddle"))
        {
            if (_pos.x <= _boundLXOuter)
            {
                _pos.x = _boundLXOuter;
            }
            else if (_pos.x >= _boundLXInner)
            {
                _pos.x = _boundLXInner;
            }
        }
        transform.position = _pos;
    }
}
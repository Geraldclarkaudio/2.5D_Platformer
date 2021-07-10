using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController _controller;

    [SerializeField]
    private float _speed = 5.0f;
    [SerializeField]
    private float _gravity = 1.0f;
    [SerializeField]
    private float _jumpHeight = 10.0f;

    private Vector3 _direction;

    [SerializeField]
    private bool _jumping = false;

    private Animator _anim;

    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _anim = GetComponentInChildren<Animator>(); // getting animator component on the child game object "Model"
    }

    // Update is called once per frame
    void Update()
    {
        CaluculateMovement();
     
    }
    
    void CaluculateMovement()
    {
        if (_controller.isGrounded == true)
        {
            if (_jumping == true)
            {
                _jumping = false;
                _anim.SetBool("Jumping", _jumping);
            }
            //horizontal movement 
            float h = Input.GetAxisRaw("Horizontal"); // using getaxisraw because the float value slowly increments to 1. Raw tells it to go to 1 asap.
            _direction = new Vector3(0, 0, h);//because moving left and right depends on the z axis her
            _anim.SetFloat("Speed", Mathf.Abs(h));
            

            //FACE CORRECT DIRECTION
            if (h != 0) // if the z axis doesnt equal 0 
            {
                Vector3 facingDirection = transform.localEulerAngles; // variable for facing direction using local Euler Angles
                facingDirection.y = _direction.z > 0 ? 0 : 180; //facing direction's y position = value of h > 0 else 0 or 180
                transform.localEulerAngles = facingDirection; //localEulerAngles = the new direction
            }
            //JUMP
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _direction.y = _jumpHeight;
                //trigger jump anim
                _jumping = true;
                _anim.SetBool("Jumping", _jumping);
            }

        }

        //needs gravity to be grounded
        _direction.y -= _gravity * Time.deltaTime;

        //Move
        _controller.Move(_direction * _speed * Time.deltaTime);
    }

    public void LedgeGrab(Vector3 handPosition)
    {
        _controller.enabled = false;
        _anim.SetBool("LedgeGrab", true);
        //update position to hand position. 
        
        transform.position = handPosition;

    }

}

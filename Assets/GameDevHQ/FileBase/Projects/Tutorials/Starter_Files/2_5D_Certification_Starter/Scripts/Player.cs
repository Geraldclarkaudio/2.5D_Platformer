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

    [SerializeField]
    private bool onLedge = false;

    [SerializeField]
    private bool onLadder = false;

    [SerializeField]
    private bool hasRolled = false;

    private LedgeGrab _activeLedge;
    private Ladder _ladder;

    [SerializeField]
    private int collectable;

    private UIManager _uiManager;

    [SerializeField]
    private Transform mainCamPos;

    [SerializeField]
    private Transform ladderWaypoint;

    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _anim = GetComponentInChildren<Animator>(); // getting animator component on the child game object "Model"
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        if(_uiManager == null)
        {
            Debug.LogError("UIMANAGER is NULL");
        }

        Camera.main.transform.position = mainCamPos.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        CaluculateMovement();

        if(onLedge == true)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                _anim.SetTrigger("ClimbUp");
            }
        } 
        if(onLadder == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, ladderWaypoint.position, 4.0f * Time.deltaTime);
        }
        if(transform.position == ladderWaypoint.position)
        {
            onLadder = false;
            _anim.SetTrigger("FinishLadder");
        }
        
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
            if(hasRolled == true)
            {
                hasRolled = false;
                _anim.SetBool("isRolling", hasRolled);
            }

            //horizontal movement 
            float h = Input.GetAxisRaw("Horizontal"); // using getaxisraw because the float value slowly increments to 1. Raw tells it to go to 1 asap.
            _direction = new Vector3(0, 0, h);//because moving left and right depends on the z axis here
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

            //ROLL
            if(Input.GetKeyDown(KeyCode.LeftShift))
            {
                _anim.SetBool("isRolling", true);
                hasRolled = true;
            }
            //CLIMB LADDER

           

        }

        //needs gravity to be grounded
        _direction.y -= _gravity * Time.deltaTime;

        //Move
        _controller.Move(_direction * _speed * Time.deltaTime);
    }

    public void LedgeGrab(Vector3 handPosition, LedgeGrab currentLedge)
    {
        onLedge = true;
        _controller.enabled = false;
        _anim.SetBool("LedgeGrab", true);
        //update position to hand position. 
        
        transform.position = handPosition;
        _anim.SetFloat("Speed", 0.0f);
        _anim.SetBool("Jumping", false);
        _activeLedge = currentLedge;

    }

    public void ClimbLadder(Vector3 handPosition, Ladder currentLadder)
    {
        onLadder = true;
        _controller.enabled = false;
        _anim.SetBool("climbLadder", true);
        _anim.SetFloat("Speed", 0.0f);
        _anim.SetBool("Jumping", false);

        transform.position = handPosition;
        _ladder = currentLadder;


    }
    public void ClimbUpComplete()
    {
        transform.position = _activeLedge.GetStandPos();
        _anim.SetBool("LedgeGrab", false);

    }

    public void ClimbLadderComplete()
    {
        transform.position = _ladder.GetStandPos();
        _anim.SetBool("climbLadder", false);
    }

    public void StandUpComplete()
    {
        _controller.enabled = true;
    }

    public void CoinCollect()
    {
        collectable++;
        _uiManager.UpdateCollected(collectable);
    }
}

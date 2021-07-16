using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftTrigger : MonoBehaviour
{
    [SerializeField]
    private bool inTrigger = false;
    private bool goingDown = false;

    [SerializeField]
    private Transform pointA;
    [SerializeField]
    private Transform pointB;
    [SerializeField]
    private float _speed = 5.0f;

    [SerializeField]
    private bool goingUp = false;

    [SerializeField]
    private Transform floorCam;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Player _player = GameObject.Find("Player").GetComponent<Player>();

            if(_player != null)
            {
                inTrigger = true;
                other.transform.parent = this.transform;//so the player stays on platform
                floorCam.transform.parent = this.transform; // so the floor virtual cam resets in the proper position when reentering
                Camera.main.transform.parent = this.transform;
                Camera.main.transform.position = floorCam.transform.position;
                Camera.main.transform.rotation = floorCam.transform.rotation;
            
            }

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            inTrigger = false;
            other.transform.parent = null;
            Camera.main.transform.parent = null;
        }
    }

    private void FixedUpdate()
    {
        if(goingDown == true)
        {
            if (goingUp == false)
            {
                transform.position = Vector3.MoveTowards(transform.position, pointB.position, _speed * Time.deltaTime);
            }

            else if (goingUp == true)
            {
                transform.position = Vector3.MoveTowards(transform.position, pointA.position, _speed * Time.deltaTime);
            }

            if (transform.position == pointB.position)
            {
                StartCoroutine(ElevatorDelayUp());
            }
            else if (transform.position == pointA.position)
            {
                StartCoroutine(ElevatorDelayDown());
            }
        }
    }

    IEnumerator ElevatorDelayDown()
    {
        yield return new WaitForSeconds(5.0f);
        goingUp = false;

    }

    IEnumerator ElevatorDelayUp()
    {
        yield return new WaitForSeconds(5.0f);
        goingUp = true;

    }

    public void CallElevator()
    {
        goingDown = true;
    }    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftTrigger : MonoBehaviour
{
    [SerializeField]
    private bool inTrigger = false;

    [SerializeField]
    private Transform pointA;
    [SerializeField]
    private Transform pointB;
    [SerializeField]
    private float _speed = 5.0f;

    [SerializeField]
    private bool goingUp = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            inTrigger = true;
            other.transform.parent = this.transform;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            inTrigger = false;
            other.transform.parent = null;
        }
    }

    private void FixedUpdate()
    {
        if(goingUp == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, pointB.position, _speed * Time.deltaTime);
        }

        else if(goingUp == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, pointA.position, _speed * Time.deltaTime);
        }

        if(transform.position == pointB.position)
        {
            StartCoroutine(ElevatorDelayUp()); // not working
        }
        else if (transform.position == pointA.position)
        {
            StartCoroutine(ElevatorDelayDown()); // not working
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
}

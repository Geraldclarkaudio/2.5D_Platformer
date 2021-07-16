using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator_Button : MonoBehaviour
{
    [SerializeField]
    private bool inTrigger;

    [SerializeField]
    private MeshRenderer Button;

    private LiftTrigger _liftTrigger;

    private bool elevatorCalled = false;

    private void Start()
    {
        _liftTrigger = GameObject.Find("Floor").GetComponent<LiftTrigger>();

        if(_liftTrigger == null)
        {
            Debug.LogError("the elevator is null");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("TriggerActive");
            inTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            inTrigger = false;
        }    
    }

    private void FixedUpdate()
    {
        if(inTrigger == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                //change materiall color of the sphere
                Button.material.color = Color.green;
                elevatorCalled = true;
                _liftTrigger.CallElevator();
            }
        }
    }
}

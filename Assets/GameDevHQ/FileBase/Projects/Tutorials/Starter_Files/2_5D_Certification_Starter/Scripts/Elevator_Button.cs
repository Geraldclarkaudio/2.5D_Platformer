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

    private void Update()
    {
        if(inTrigger == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if(elevatorCalled == false)
                {
                    Button.material.color = Color.green;
                    elevatorCalled = true;
                    _liftTrigger.CallElevator();
                }
                else
                {
                    Button.material.color = Color.red;
                    elevatorCalled = false;
                    _liftTrigger.StopElevator();
                }
                
            }
        }
    }
}

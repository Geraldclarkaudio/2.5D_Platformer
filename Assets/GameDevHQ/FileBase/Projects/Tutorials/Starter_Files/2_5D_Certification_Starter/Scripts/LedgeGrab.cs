using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LedgeGrab : MonoBehaviour
{
    //handle to hand position
    [SerializeField]
    private Vector3 handPosition;

    [SerializeField]
    private Vector3 standPosition;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag ("Ledge_Grab_Checker"))
        {
            //disable character controller

            //get player component
            var player = other.transform.parent.GetComponent<Player>();
            if(player != null)
            {
                //call ledge grab method
                player.LedgeGrab(handPosition, this);
            }
        }
    }
    public Vector3 GetStandPos()
    {
        return standPosition;
    }
}

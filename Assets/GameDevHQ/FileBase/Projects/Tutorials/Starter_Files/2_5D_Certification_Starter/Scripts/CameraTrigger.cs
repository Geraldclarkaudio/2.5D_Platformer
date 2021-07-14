using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
    public Transform _cameraAssigned;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("Trigger Activated");
            Camera.main.transform.position = _cameraAssigned.transform.position;
            Camera.main.transform.rotation = _cameraAssigned.transform.rotation;
        }
    }
}

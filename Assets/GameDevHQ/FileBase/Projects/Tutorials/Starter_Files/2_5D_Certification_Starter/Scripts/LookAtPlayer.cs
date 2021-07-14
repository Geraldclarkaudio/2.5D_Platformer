using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform _target;

    public Transform _floorCam;

    // Update is called once per frame
    void Update()
    {
        if(transform.position == _floorCam.transform.position)
        {
            transform.LookAt(_target);
        }
       
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField]
    private Transform pointA;
    [SerializeField]
    private Transform pointB;

    [SerializeField]
    private float _speed = 5.0f;

    private bool moveToB;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(moveToB == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, pointB.position, _speed * Time.deltaTime);
        }
        else if(moveToB == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, pointA.position, _speed * Time.deltaTime);

        }
        
        if(transform.position == pointB.position)
        {
            moveToB = false;
        }
        else if( transform.position == pointA.position)
        {
            moveToB = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.transform.parent = this.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            other.transform.parent = null;

        }
    }

}

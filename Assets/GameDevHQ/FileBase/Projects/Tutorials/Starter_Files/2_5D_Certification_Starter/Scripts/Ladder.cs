using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    private Player _player;

    [SerializeField]
    private bool canClimb = false;

    [SerializeField]
    private Vector3 handPosition;

    [SerializeField]
    private Vector3 standPosition;

    private void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            canClimb = true;
            _player.ClimbLadder(handPosition, this);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            canClimb = false;
        }    
    }

    public Vector3 GetStandPos()
    {
        return standPosition;
    }
}


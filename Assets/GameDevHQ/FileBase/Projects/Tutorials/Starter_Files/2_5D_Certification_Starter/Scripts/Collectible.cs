using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    private float angle = 3f;

    private Player _player;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0,1,0), angle);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if(_player != null)
            {
                _player.CoinCollect();

                Destroy(this.gameObject);
            }
          
        }
    }
}

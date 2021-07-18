using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPlatform : MonoBehaviour
{
    private UIManager _uiManager;

    private Player player;

    void Start()
    {
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            //you win UI
            _uiManager.WinScreen();
            
            //press a button to start over. 

        }
    }
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {

    }
}

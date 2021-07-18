using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text _collectText;

    [SerializeField]
    private Image fadeImg;
    [SerializeField]
    private Text WinText;
    [SerializeField]
    private Button StartOver;

    [SerializeField]
    private GameObject winScreenGameObject;


    private int collectedLamps;
    public void UpdateCollected(int coins)
    {
        _collectText.text = "Lamps Collected: " + coins;
    }

    public void WinScreen()
    {
        winScreenGameObject.SetActive(true);  
    }
}

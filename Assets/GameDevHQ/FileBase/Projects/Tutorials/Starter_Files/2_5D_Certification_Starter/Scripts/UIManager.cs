using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text _collectText;

    private int collectedLamps;
    public void UpdateCollected(int coins)
    {
        _collectText.text = "Lamps Collected: " + coins;
    }
}

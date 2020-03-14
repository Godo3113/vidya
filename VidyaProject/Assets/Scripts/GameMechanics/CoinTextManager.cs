using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinTextManager : MonoBehaviour
{

    public Inventory playerInventory;
    public TextMeshProUGUI coindDisplay;

    public void UpdateCoinCount()
    {
        coindDisplay.text = "" + playerInventory.coins;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CashUI : MonoBehaviour {

    public Text cash;

    private void Update()
    {
        cash.text = "$" + PlayerStats.Cash.ToString();
    }
}

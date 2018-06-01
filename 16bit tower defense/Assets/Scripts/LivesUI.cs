using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesUI : MonoBehaviour {

    public Text Lives;

    private void Update()
    {
        Lives.text = PlayerStats.Lives.ToString() + "/" + PlayerStats.startLives.ToString();
    }
}

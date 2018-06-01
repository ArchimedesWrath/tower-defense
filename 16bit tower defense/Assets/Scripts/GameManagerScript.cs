using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour {
	
    public static bool gameEnded = false;
	void Update () {
        if (gameEnded) return;
		if (PlayerStats.Lives <= 0)
        {
            EndGame();
        }
	}

    private void EndGame()
    {
        Debug.Log("GameOver");
        gameEnded = true;
    }
}

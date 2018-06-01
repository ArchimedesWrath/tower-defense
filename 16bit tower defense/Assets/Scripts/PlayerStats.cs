using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

    public static int Cash;
    public int startCash = 5;
    public static int Lives;
    public static int startLives = 20;

    private void Start()
    {
        Cash = startCash;
        Lives = startLives;
    }

    public static void DamagePlayer()
    {
        Lives--;
    }
}

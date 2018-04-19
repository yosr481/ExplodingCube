using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {

    public static float spawnEverySeconds = 1;
    public static float timer = 0;

    public static string SecondsToString(int sec)
    {
        int minutes = sec / 60;
        int seconds = sec % 60;

        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}

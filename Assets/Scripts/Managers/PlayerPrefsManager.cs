using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsManager : MonoBehaviour {

    const string MASTER_VOLUME_KEY = "master_volume";
    const string TIME_CHALLAENGE_AMOUNT = "time_amount";

    public static void SetVolume(float volume)
    {
        if (volume > 0 && volume < 1)
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
        else
            Debug.LogError("Volume out of range.");
    }

    public static float GetVolume()
    {
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
    }

    public static void SetTimeAmount(float amount)
    {
        if (amount > 30 && amount < 90)
            PlayerPrefs.SetFloat(TIME_CHALLAENGE_AMOUNT, amount);
        else
            Debug.LogError("Time amount out of range.");
    }

    public static float GetTimeAmount()
    {
        return PlayerPrefs.GetFloat(TIME_CHALLAENGE_AMOUNT);
    }
}

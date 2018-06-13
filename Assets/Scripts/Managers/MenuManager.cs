using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MenuManager : MonoBehaviour {

    public int amount;
    public Slider slider;
    public Text amountText;

	public void UpdateText()
    {
        amountText.text = slider.value.ToString();
    }

    public void OpenTimeChallange()
    {
        PlayerPrefsManager.SetTimeAmount(slider.value);
        SceneManager.LoadScene("Time Challenge");
    }
}

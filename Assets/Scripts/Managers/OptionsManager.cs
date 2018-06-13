using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsManager : MonoBehaviour {

    public Slider volumeSlider;
    MusicPlayer player;

    private void Awake()
    {
        player = FindObjectOfType<MusicPlayer>();
        player.SetVolume(PlayerPrefsManager.GetVolume());
        volumeSlider.value = PlayerPrefsManager.GetVolume();
    }

    private void Update()
    {
        player.SetVolume(volumeSlider.value);
    }

    public void SaveAndExit()
    {
        PlayerPrefsManager.SetVolume(volumeSlider.value);
        SceneManager.LoadScene("Main");
    }

    public void SaveWithoutExit()
    {
        SceneManager.LoadScene("Main");
    }

    public void SetDefault()
    {
        volumeSlider.value = .6f;
    }
}

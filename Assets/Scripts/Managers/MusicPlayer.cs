using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour
{
    static MusicPlayer instance = null;

    private AudioSource music;

    void Start()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            music = GetComponent<AudioSource>();
            music.loop = true;
            music.Play();
        }
    }

    public void SetVolume(float volume)
    {
        music.volume = volume;
    }
}
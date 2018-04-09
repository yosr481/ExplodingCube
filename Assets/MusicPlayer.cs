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
            print("Duplicate music player self-destructing!");
        }
        else
        {
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
            music = GetComponent<AudioSource>();
            music.loop = true;
            music.Play();
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JukeboxMusic : MonoBehaviour
{
    [Header("Singleton")]
    public static JukeboxMusic instance;
    [Header("Components")]
    private AudioSource actualAudioSourceMusic;
    public AudioClip actualAudioClip;
    // Start is called before the first frame update
    void Start()
    {
        actualAudioSourceMusic = GetComponent<AudioSource>();
        instance = this;   
    }

    public void PlayMusic(AudioClip newMusic)
    {
        actualAudioSourceMusic.Stop();
        actualAudioClip = newMusic;
        actualAudioSourceMusic.clip = actualAudioClip;
        actualAudioSourceMusic.Play();

    }
    public void PauseMusic()
    {
        actualAudioSourceMusic.Pause();
    }
    public void StopMusic()
    {
        actualAudioSourceMusic.Stop();
    }
}

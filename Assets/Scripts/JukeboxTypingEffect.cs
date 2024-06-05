using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JukeboxTypingEffect : MonoBehaviour
{
    [Header("Singleton")]
    public static JukeboxTypingEffect instance;
    [Header("Components")]
    private AudioSource actualAudioSourceMusic;
    public AudioClip actualAudioClip;
    // Start is called before the first frame update
    void Start()
    {
        actualAudioSourceMusic = GetComponent<AudioSource>();
        instance = this;   
    }

    public void PlayEffect(AudioClip newMusic)
    {
        actualAudioClip = newMusic;
        actualAudioSourceMusic.clip = actualAudioClip;
        actualAudioSourceMusic.Play();

    }
    public void StopEffect()
    {
        actualAudioSourceMusic.Stop();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JukeboxEffects : MonoBehaviour
{
    [Header("Singleton")]
    public static JukeboxEffects instance;
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
}

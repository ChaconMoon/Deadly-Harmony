using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionJukebox : MonoBehaviour
{
    bool isCharacterNear;
    bool canInteract= true;
    public AudioClip easterEggAudio;
    private AudioClip previusAudioClip;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("InteractionPoint") && canInteract)
        {
            Debug.Log("Dentro Interacción");
            UIControl.UIOptions.ChangeInteractionActionToInteract();
            isCharacterNear = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("InteractionPoint"))
        {
            Debug.Log("Fuera Interacción");
            UIControl.UIOptions.ChangeInteractionIconToCross();
            isCharacterNear = false;
        }
    }
    public void InteractionEffect()
    {
        previusAudioClip = JukeboxMusic.instance.actualAudioClip;
        JukeboxMusic.instance.PlayMusic(easterEggAudio);
        StartCoroutine(RestartMusic());
        
    }
    private void Update()
    {
        if (CharacterMove.characterOptions.isInteractive && isCharacterNear && canInteract)
        {
            InteractionEffect();
            canInteract = false;
            StartCoroutine(Cooldown());
        }
    }
    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(easterEggAudio.length);
        canInteract= true;
    }
    IEnumerator RestartMusic()
    {
        yield return new WaitForSeconds(easterEggAudio.length);
        JukeboxMusic.instance.PlayMusic(previusAudioClip);
    }
}

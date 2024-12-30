using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class GameManager : MonoBehaviour
{
    public DialogueContent starterDialogue;
    public CharacterController mainCharacter;
    public AudioClip startBackgroundMusic;
    public static GameManager gameManager;
    public Game_Localization starterLocalization;
    public GameObject dedicatoria;

    public bool startDevMode;


    private void Start()
    {
        SetStarterLocalization();
        gameManager = this;
        dedicatoria.SetActive(false);
        if (!startDevMode)
        {
            StartCoroutine(ShowDedicatoria());
        }
    }
    public IEnumerator StartGame()
    {
        yield return new WaitForSeconds(0.1f);
        DialogueControl.dialogueControl.StartConversation(starterDialogue);

    }
    public void ExternalStartMusic()
    {
        StartCoroutine(StartMusic());
    }
    public IEnumerator StartMusic()
    {
        yield return new WaitForSeconds (0.1f);
        JukeboxMusic.instance.PlayMusic(startBackgroundMusic);
    }
    public void SetStarterLocalization()
    {
        switch (starterLocalization)
        {
            case Game_Localization.es:
                LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[0];
                break;
            case Game_Localization.jp:
                LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[1];
                break;
            case Game_Localization.en:
                LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[2];
                break;
            case Game_Localization.mx:
                LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[3];
                break;

        }
    }
    public IEnumerator ShowDedicatoria()
    {
        dedicatoria.SetActive(true);
        yield return new WaitForSeconds(5f);
        dedicatoria.SetActive(false);
        StartCoroutine(StartGame());
        StartCoroutine(StartMusic());

    }
    public enum Game_Localization
    {
        es,jp,en,mx
    }
}

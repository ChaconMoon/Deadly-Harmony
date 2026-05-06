using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;
using UnityEngine.Localization.Settings;

public class GameManager : MonoBehaviour
{
    [Header("Player Input")]
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private string keyboardControlScheme = "Teclado";
    [SerializeField] private string gamepadControlScheme = "Mando";
    [SerializeField] private bool autoSwitchControlSchemes = true;

    public DialogueContent starterDialogue;
    public CharacterMove mainCharacter;
    public AudioClip startBackgroundMusic;
    public static GameManager gameManager;
    public Game_Localization starterLocalization;

    private IDisposable controlSchemeListener;

    //    public GameObject dedicatoria;

    private void OnEnable()
    {
        ResolvePlayerInput();

        if (!autoSwitchControlSchemes || playerInput == null)
        {
            return;
        }

        playerInput.neverAutoSwitchControlSchemes = true;
        controlSchemeListener = InputSystem.onAnyButtonPress.Call(OnAnyButtonPressed);
        ApplyInitialControlScheme();
    }

    private void OnDisable()
    {
        controlSchemeListener?.Dispose();
        controlSchemeListener = null;
    }

    private void Start()
    {
        //dedicatoria.SetActive(false);
        SetStarterLocalization();
        gameManager = this;
        StartCoroutine(ShowDedicatoria());
    }

    private void ResolvePlayerInput()
    {
        if (playerInput == null)
        {
            playerInput = FindFirstObjectByType<PlayerInput>();
        }
    }

    private void ApplyInitialControlScheme()
    {
        if (playerInput == null || !string.IsNullOrEmpty(playerInput.currentControlScheme))
        {
            return;
        }

        if (Keyboard.current != null && !string.IsNullOrWhiteSpace(keyboardControlScheme))
        {
            playerInput.SwitchCurrentControlScheme(keyboardControlScheme, Keyboard.current);
            return;
        }

        if (Gamepad.current != null && !string.IsNullOrWhiteSpace(gamepadControlScheme))
        {
            playerInput.SwitchCurrentControlScheme(gamepadControlScheme, Gamepad.current);
        }
    }

    private void OnAnyButtonPressed(InputControl control)
    {
        if (!autoSwitchControlSchemes || playerInput == null || control == null)
        {
            return;
        }

        if (control.device is Gamepad gamepad)
        {
            SwitchControlScheme(gamepadControlScheme, gamepad);
            return;
        }

        if (control.device is Keyboard || control.device is Mouse)
        {
            if (Keyboard.current != null)
            {
                SwitchControlScheme(keyboardControlScheme, Keyboard.current);
            }
        }
    }

    private void SwitchControlScheme(string controlScheme, InputDevice device)
    {
        if (string.IsNullOrWhiteSpace(controlScheme) || device == null)
        {
            return;
        }

        if (playerInput.currentControlScheme == controlScheme)
        {
            return;
        }

        playerInput.SwitchCurrentControlScheme(controlScheme, device);
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
        yield return new WaitForSeconds(0.1f);
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
        //dedicatoria.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        //dedicatoria.SetActive(false);
        StartCoroutine(StartGame());
        StartCoroutine(StartMusic());
    }

    public enum Game_Localization
    {
        es, jp, en, mx
    }
}

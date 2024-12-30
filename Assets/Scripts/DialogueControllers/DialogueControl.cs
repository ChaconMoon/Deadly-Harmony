using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Localization.Components;
using UnityEngine.UI;

/// <summary>
/// DialogueControl control the UI with the dialogue and Sets the content
/// </summary>
public class DialogueControl : MonoBehaviour
{
    /// The objects in UI Parts are the parts that the Dialogue control need to reference

    /// <summary>
    /// The reference to the UI base GameObject
    /// </summary>
    [Header("UI Parts")]
    public GameObject dialogueUI;

    /// <summary>
    /// The reference to the character gameObject in the left
    /// </summary>
    public GameObject characterLeft;

    /// <summary>
    /// The reference to the character gameObject in the right
    /// </summary>
    public GameObject characterRight;

    /// <summary>
    /// The reference to the gameObject with the Dialogue box
    /// </summary>
    public GameObject dialogueBox;

    /// <summary>
    /// The reference to the gameObject with the name of character in the left 
    /// </summary>
    public GameObject characterBoxLeft;

    /// <summary>
    /// The reference to the gameObject with the name of character in the right 
    /// </summary>
    public GameObject characterBoxRight;

    /// <summary>
    /// dialogues cointain the list of the dialogues of the actual conversation of the game.
    /// </summary>
    [Header("Dialogue Content")]
    private Dialogue[] dialogues;

    /// <summary>
    /// actualDialogue is a iterative int used get the dialogues in the list in order.
    /// </summary>
    private int actualDialogue;

    /// <summary>
    /// The Singleton object of this class
    /// </summary>
    [Header("Singleton")]
    public static DialogueControl dialogueControl;

    /// This are the components of the objects of the UI Parts and Dialogues

    /// <summary>
    /// The Image component of the Character at the left
    /// </summary>
    [Header("UI Components")]
    private Image characterLeftSprite;

    /// <summary>
    /// The Image component of the Character at the right
    /// </summary>
    private Image characterRightSprite;

    /// <summary>
    /// The Text component that show the text in the Dialogue UI
    /// </summary>
    private TextMeshProUGUI actualTextDialogueUI;

    /// <summary>
    /// The text of the dialogue in the UI
    /// </summary>
    private string actualTextDialogue;

    /// <summary>
    /// The name of the Character at the Left
    /// </summary>
    private string actualNameCharacterLeft;

    /// <summary>
    /// The name of the Character at the Right
    /// </summary>
    private string actualNameCharacterRight;

    /// <summary>
    /// The reference to the text component that contain the name Character at the Left
    /// </summary>
    private TextMeshProUGUI actualNameCharacterLeftOnUI;

    /// <summary>
    /// The reference to the text component that contain the name Character at the Right
    /// </summary>
    private TextMeshProUGUI actualNameCharacterRightOnUI;

    /// <summary>
    /// The reference to the Co-rutine that writes the Dialogue in the UI
    /// </summary>
    private IEnumerator writeDialogues;

    /// <summary>
    /// The reference to the Audio effect that sound when the UI write te text
    /// </summary>
    public AudioClip audioTypingEffect;

    /// <summary>
    /// The reference to the Animator that execute the animations of the game
    /// </summary>
    public Animator GlobalCharacterAnimator;

    /// <summary>
    /// The object that the Game use to get a String of one of the Game Lenguages
    /// </summary>
    [Header("Localization")]
    private LocalizeStringEvent stringEvent;


    /// <summary>
    /// Initialice all the Component that use the dialogue UI
    /// </summary>
    void Start()
    {
        stringEvent = GetComponent<LocalizeStringEvent>();
        characterLeftSprite = characterLeft.GetComponent<Image>();
        characterRightSprite = characterRight.GetComponent<Image>();
        actualTextDialogueUI = dialogueBox.GetComponentInChildren<TextMeshProUGUI>();
        actualNameCharacterLeftOnUI = characterBoxLeft.GetComponentInChildren<TextMeshProUGUI>();
        actualNameCharacterRightOnUI = characterBoxRight.GetComponentInChildren<TextMeshProUGUI>();
        actualDialogue = 0;
        dialogueUI.SetActive(false);
        writeDialogues = WriteDilogue();

    }
    private void Awake()
    {
        dialogueControl = this;
    }

    private void GetCharacterLeft()
    {
        if (DialoguesShowNames())
        {
            characterLeftSprite.enabled = true;
            characterLeftSprite.sprite = dialogues[actualDialogue].ReturnSpriteLeft();
        }
        else
        {
            characterLeftSprite.enabled = false;
        }
        actualNameCharacterLeft = dialogues[actualDialogue].infoCharacterLeft.characterNameInDialogues;
    }
    private void GetCharacterRight()
    {
            if(DialoguesShowNames()) {
            characterRightSprite.enabled = true;
            characterRightSprite.sprite = dialogues[actualDialogue].ReturnSpriteRight();
            }
            else {
            characterRightSprite.enabled = false;
            }
            actualNameCharacterRight = dialogues[actualDialogue].infoCharacterRight.characterNameInDialogues;
    }
    private void SetCharacterLeftinUI()
    {
        if (DialoguesShowNames())
        {


            if (dialogues[actualDialogue].whoIsTalking == WhoIsTalking.Left)
            {
                characterBoxLeft.SetActive(true);
            }
            else
            {
                characterBoxLeft.SetActive(false);
            }
            actualNameCharacterLeftOnUI.text = actualNameCharacterLeft;
        }
        else
        {
            characterBoxLeft.SetActive(false);
        }
    }
    private void SetCharacterRightinUI()
    {
        if (DialoguesShowNames())
        {


            if (dialogues[actualDialogue].whoIsTalking == WhoIsTalking.Right)
            {
                characterBoxRight.SetActive(true);
            }
            else
            {
                characterBoxRight.SetActive(false);
            }
            actualNameCharacterRightOnUI.text = actualNameCharacterRight;
        }
        else
        {
            characterBoxRight.SetActive(false);
        }
    }

    public void SetDialogues(DialogueContent newDialogue) {
        dialogues = newDialogue.dialogues;
    }
    private void SetActualDialogue()
    {
        stringEvent.StringReference.SetReference("GameDialogues", dialogues[actualDialogue].name);
        actualTextDialogue = stringEvent.StringReference.GetLocalizedString();
    }
    public void ShowActualDialogue()
    {
        if (dialogues[actualDialogue].hasEvents)
        {
            if (dialogues[actualDialogue].eventType == EventType.PlayAnimation || dialogues[actualDialogue].eventType == EventType.Narrator)
            {
                if (dialogues[actualDialogue].animationName != "")
                {
                    Debug.Log(dialogues[actualDialogue].animationName);
                    GlobalCharacterAnimator.Play(dialogues[actualDialogue].animationName);
                }
            }
            if (dialogues[actualDialogue].eventType == EventType.MoveCamera || dialogues[actualDialogue].eventType == EventType.Narrator)
            {
                if (dialogues[actualDialogue].newCameraPosition != "" )
                {
                    Vector3 newCameraPosition = GameObject.Find(dialogues[actualDialogue].newCameraPosition).transform.position;
                    Camera.main.transform.position = newCameraPosition;
                }
            }
            if (dialogues[actualDialogue].eventType == EventType.PlayMusic)
            {
                JukeboxMusic.instance.PlayMusic(dialogues[actualDialogue].dialogueAudio);
            }
            if (dialogues[actualDialogue].eventType == EventType.PlayEffect)
            {
                JukeboxEffects.instance.PlayEffect(dialogues[actualDialogue].dialogueAudio);
            }
            if (dialogues[actualDialogue].eventType == EventType.RestartBackGroundMusic)
            {
                GameManager.gameManager.ExternalStartMusic();
            }
            if (dialogues[actualDialogue].eventType == EventType.AddCharacterInMenu)
            {
                if (CharacterInMenuControl.instance.IsCharacterAdded(dialogues[actualDialogue].characterToAdd))
                {
                    GoToNextDialogue();
                    return;
                }
            }
            else if (dialogues[actualDialogue].eventType == EventType.AddObjectInMenu)
            {
                if (ItemInMenuControl.instance.IsItemAdded(dialogues[actualDialogue].itemToAdd))
                {
                    Debug.Log("ItemAddedError");
                    GoToNextDialogue();
                    return;
                }

            }
        }
        dialogueUI.SetActive(true);
        EarseDialogueUI();
        GetCharacterLeft();
        GetCharacterRight();
        SetActualDialogue();
        SetCharacterLeftinUI();
        SetCharacterRightinUI();
        StopCoroutine(writeDialogues);
        writeDialogues = WriteDilogue();
        JukeboxTypingEffect.instance.PlayEffect(audioTypingEffect);
        StartCoroutine(writeDialogues);
        if (dialogues[actualDialogue].hasEvents)
        {
            if (dialogues[actualDialogue].eventType == EventType.AddCharacterInMenu)
            {
                CharacterInMenuControl.instance.AddCharacterInIcon(dialogues[actualDialogue].characterToAdd);
            }
            else if (dialogues[actualDialogue].eventType == EventType.AddObjectInMenu)
            {
                ItemInMenuControl.instance.AddItemInIcon(dialogues[actualDialogue].itemToAdd);
            }
            else if (dialogues[actualDialogue].eventType == EventType.ShowAchivement)
            {
                AchievementControl.instance.ValidateAchievement(dialogues[actualDialogue].achivementToGet);
            }
        }
    }
    public void GoToNextDialogue()
    {
        actualDialogue++;
        if (dialogues[actualDialogue - 1].eventType == EventType.MoveCameraToResetPosition)
        {
            Debug.Log("ResetCamera");
            Vector3 newCameraPosition = GameObject.Find("CameraPosition1").transform.position;
            Camera.main.transform.position = newCameraPosition;
            EndConversation();
        }

        if (actualDialogue == dialogues.Length && !(dialogues[actualDialogue-1].eventType == EventType.ShowNextDialogue))
        {
           EndConversation();
        }
        else if (dialogues[actualDialogue-1].hasEvents && dialogues[actualDialogue-1].eventType == EventType.ShowNextDialogue)
        {
            StartConversation(dialogues[actualDialogue - 1].nextDialogueToShow);
        }
        else
        {
            ShowActualDialogue();
        }

    }
    public IEnumerator WriteDilogue()
    {
        char[] chars = actualTextDialogue.ToCharArray();
        yield return new WaitForSeconds(0.3f);
        for (int i = 0; i < chars.Length; i++)
        {
            yield return new WaitForSeconds(0.03f);
            actualTextDialogueUI.text += chars[i];
        }
        JukeboxTypingEffect.instance.StopEffect();

    }
    public void EarseDialogueUI()
    {
        actualTextDialogueUI.text = "";
    }

    private void EndConversation()
    {
        Debug.Log("EndConversation");
        EarseDialogueUI();
        dialogueUI.SetActive(false);
        CharacterController.characterController.StopTalking();
    }
    public void StartConversation(DialogueContent dialogue)
    {
        actualDialogue = 0;
        CharacterController.characterController.StartTalking();
        //JukeboxMusic.instance.PauseMusic();
        SetDialogues(dialogue);
        EarseDialogueUI();
        dialogueUI.SetActive(true);
        ShowActualDialogue();
    }
    public bool DialoguesShowNames()
    {
        if (!dialogues[actualDialogue].hasEvents 
            || dialogues[actualDialogue].eventType == EventType.ShowNextDialogue 
            || dialogues[actualDialogue].eventType == EventType.MoveCamera 
            || dialogues[actualDialogue].eventType == EventType.MoveCameraToResetPosition
            || dialogues[actualDialogue].eventType == EventType.ShowAchivement
            || dialogues[actualDialogue].eventType == EventType.PlayMusic
            || dialogues[actualDialogue].eventType == EventType.RestartBackGroundMusic
            || dialogues[actualDialogue].eventType == EventType.PlayAnimation)
        {
            return true;
        }
        else
        {
            return false;
        }
    }


}

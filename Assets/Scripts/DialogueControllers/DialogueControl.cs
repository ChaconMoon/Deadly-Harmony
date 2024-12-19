using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Localization.Components;
using UnityEngine.UI;

public class DialogueControl : MonoBehaviour
{
    [Header("Partes UI")]
    public GameObject dialogueUI;
    public GameObject characterLeft;
    public GameObject characterRight;
    public GameObject dialogueBox;
    public GameObject characterBoxLeft;
    public GameObject characterBoxRight;

    [Header("Dialogue Content")]
    private DialogueContent dialogueContent;
    private Dialogue[] dialogues;
    private int actualDialogue;

    [Header("Singleton")]
    public static DialogueControl dialogueControl;

    [Header("Components")]
    private Image characterLeftSprite;
    private Image characterRightSprite;
    private TextMeshProUGUI actualTextDialogueUI;
    private string actualTextDialogue;
    private string actualNameCharacterLeft;
    private string actualNameCharacterRight;
    private TextMeshProUGUI actualNameCharacterLeftOnUI;
    private TextMeshProUGUI actualNameCharacterRightOnUI;
    private IEnumerator writeDialogues;
    public AudioClip audioTypingEffect;
    public Animator GlobalCharacterAnimator;

    [Header("Localization")]
    private LocalizeStringEvent stringEvent;
    private string actualLocalizateStringDialogue;

    // Start is called before the first frame update
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

    // Update is called once per frame
    void Update()
    {
        /**
         if (Input.GetKeyDown(KeyCode.Tab))
        {
            GoToNextDialogue();
        }
        **/
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
        CharacterMove.characterOptions.StopTalking();
    }
    public void StartConversation(DialogueContent dialogue)
    {
        actualDialogue = 0;
        CharacterMove.characterOptions.StartTalking();
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

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
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

    // Start is called before the first frame update
    void Start()
    {
        dialogueControl = this;       
        characterLeftSprite = characterLeft.GetComponent<Image>();
        characterRightSprite = characterRight.GetComponent<Image>();
        actualTextDialogueUI = dialogueBox.GetComponentInChildren<TextMeshProUGUI>();
        actualNameCharacterLeftOnUI = characterBoxLeft.GetComponentInChildren<TextMeshProUGUI>();
        actualNameCharacterRightOnUI = characterBoxRight.GetComponentInChildren<TextMeshProUGUI>();
        actualDialogue = 0;
        dialogueUI.SetActive(false);
        writeDialogues = WriteDilogue();

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
        if (!dialogues[actualDialogue].hasEvents)
        {
            characterLeftSprite.sprite = dialogues[actualDialogue].ReturnSpriteLeft();
            actualNameCharacterLeft = dialogues[actualDialogue].infoCharacterLeft.characterName;
        }
    }
    private void GetCharacterRight()
    {
        characterRightSprite.sprite = dialogues[actualDialogue].ReturnSpriteRight();
        actualNameCharacterRight = dialogues[actualDialogue].infoCharacterRight.characterName;
    }
    private void SetCharacterLeftinUI()
    {
        if (!dialogues[actualDialogue].hasEvents)
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
        if (!dialogues[actualDialogue].hasEvents)
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
        actualTextDialogue = dialogues[actualDialogue].dialogueText;
    }
    public void ShowActualDialogue()
    {
        dialogueUI.SetActive(true);
        EarseDialogue();
        GetCharacterLeft();
        GetCharacterRight();
        SetActualDialogue();
        SetCharacterLeftinUI();
        SetCharacterRightinUI();
        StopCoroutine(writeDialogues);
        writeDialogues = WriteDilogue();
        if (dialogues[actualDialogue].hasEvents)
        {
            if (dialogues[actualDialogue].eventType == EventType.AddCharacterInMenu)
            {
                CharacterInMenuControl.instance.AddCharacterInIcon(dialogues[actualDialogue].characterToAdd);
            }
        }
        StartCoroutine(writeDialogues);
    }
    public void GoToNextDialogue()
    {
        actualDialogue++;
        if (actualDialogue != dialogues.Length)
        {
            ShowActualDialogue();
        } else
        {
            EndConversation();
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

    }
    public void EarseDialogue()
    {
        actualTextDialogueUI.text = "";
    }

    private void EndConversation()
    {
        EarseDialogue();
        actualDialogue = 0;
        dialogueUI.SetActive(false);
        CharacterMove.characterOptions.StopTalking();
    }
    public void StartConversation(DialogueContent dialogue)
    {
        CharacterMove.characterOptions.StartTalking();
        SetDialogues(dialogue);
        EarseDialogue();
        dialogueUI.SetActive(true);
        ShowActualDialogue();
    }


}

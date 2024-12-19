using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueOptionsInUI : MonoBehaviour
{
    [Header("Singleton")]
    public static DialogueOptionsInUI instance;

    [Header("UIOptions")]
    public GameObject[] optionsInUI = new GameObject[4];

    [Header("Componentes GameObjects")]
    private TextMeshProUGUI[] titulosMensajeinUI = new TextMeshProUGUI[4];
    private Button[] uiButtons = new Button[4];

    [Header("DialogueOptions")]
    private DialogueOptions dialogueOptions;

    // Start is called before the first frame update
    void Start()
    {
        EarseOptions();
        instance = this;
        //InstanciateDialogue();
    }

    public void StartDialogoOptionOne()
    {
        Debug.Log("StartOptionOne");
        DialogueControl.dialogueControl.StartConversation(dialogueOptions.dialogues[0]);
        EarseOptions();

    }
    public void StartDialogoOptionTwo()
    {
        Debug.Log("StartOptionTwo");

        DialogueControl.dialogueControl.StartConversation(dialogueOptions.dialogues[1]);
        EarseOptions();
    }
    public void StartDialogoOptionThree()
    {

        Debug.Log("StartOptionThree");

        DialogueControl.dialogueControl.StartConversation(dialogueOptions.dialogues[2]);
        EarseOptions();

    }
    public void StartDialogoOptionFour()
    {

        Debug.Log("StartOptionFour");
        DialogueControl.dialogueControl.StartConversation(dialogueOptions.dialogues[3]);
        EarseOptions();


    }
    public void InstanciateDialogue(DialogueOptions dialogue)
    {
        dialogueOptions = dialogue;
        for (int i = 0; i < optionsInUI.Length; i++)
        {
            optionsInUI[i].SetActive(true);
            titulosMensajeinUI[i] = optionsInUI[i].GetComponentInChildren<TextMeshProUGUI>();
            titulosMensajeinUI[i].text = dialogueOptions.dialogueTitle[i];
            uiButtons[i] = optionsInUI[i].GetComponent<Button>();
            uiButtons[i].interactable = dialogueOptions.activateDialogues[i];
            if (!uiButtons[i].interactable)
            {
                titulosMensajeinUI[i].text = "??????";
            }
        }
    }
    public void EarseOptions()
    {
        for (int i = 0; i < optionsInUI.Length; i++)
        {
            if (uiButtons[i] != null)
            {
                uiButtons[i].interactable = false;
            }
            optionsInUI[i].SetActive(false);
        }
    }
    private IEnumerator CoolDownClick(int indice)
    {
        yield return new WaitForEndOfFrame();
        DialogueControl.dialogueControl.StartConversation(dialogueOptions.dialogues[indice]);
    }
}

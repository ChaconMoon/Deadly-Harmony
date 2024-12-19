using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueActivator01_FERNANDOBODY : MonoBehaviour
{
    public DialogueContent dialogueActivator;
    public NPCController NPCControllerAlex;
    public NPCController NPCControllerTiffany;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Dentro DialogueActivator No Activate");

            if (ItemInMenuControl.instance.boodBodyWasGetted && ItemInMenuControl.instance.neckMarksWasGetted)
            {
                Debug.Log("Dentro DialogueActivator");
                StartCoroutine(ExecuteDialogue());
            }

        }
    }
    public IEnumerator ExecuteDialogue()
    {
        yield return new WaitForSeconds(0.2f);
        DialogueControl.dialogueControl.StartConversation(dialogueActivator);
        NPCControllerAlex.NPCDialogue.activateDialogues[1] = true;
        NPCControllerAlex.NPCDialogue.activateDialogues[0] = false;
        NPCControllerTiffany.NPCDialogue.activateDialogues[0] = true;
        Destroy(gameObject);

    }
}

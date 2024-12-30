using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is a Eventy_Type class that set the event FERNANDOBODY
/// </summary>
public class DialogueActivator01_FERNANDOBODY : MonoBehaviour
{
    /// <summary>
    /// The dialogue of the event
    /// </summary>
    public DialogueContent dialogueActivator;

    /// <summary>
    /// The NPCController of the NPCController of the character Alex
    /// </summary>
    public NPCController NPCControllerAlex;

    /// <summary>
    /// The NPCController of the NPCController of the character Tiffany
    /// </summary>
    public NPCController NPCControllerTiffany;

    /// <summary>
    /// Execute the event if the object is in the inventory and the player enter in the trigger
    /// </summary>
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

    /// <summary>
    /// Activate the No Playable Characters Alex and Tiffany and destroy itself
    /// </summary>
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

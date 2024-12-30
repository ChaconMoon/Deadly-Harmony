using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetItem : MonoBehaviour
{
    bool isCharacterNear;
    bool canInteract = true;
    public DialogueContent getItemDialogues;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("InteractionPoint"))
        {
            Debug.Log("Dentro Interacci�n");
            UIControl.UIOptions.ChangeInteractionActionToPick();
            isCharacterNear = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("InteractionPoint"))
        {
            Debug.Log("Fuera Interacci�n");
            UIControl.UIOptions.ChangeInteractionIconToCross();
            isCharacterNear = false;
        }
    }
    public IEnumerator InteractionEffect()
    {
        yield return new WaitForSeconds(0.2f);
        DialogueControl.dialogueControl.StartConversation(getItemDialogues);
        Destroy(gameObject);

    }
    private void Update()
    {
        if (CharacterController.characterController.isInteractive && isCharacterNear && canInteract)
        {
            canInteract = false;
            StartCoroutine(InteractionEffect());
        }
    }
}

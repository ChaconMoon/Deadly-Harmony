using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    public DialogueOptions NPCDialogue;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("InteractionPoint"))
        {
            Debug.Log("Dentro Interacción");
            CharacterController.characterController.SetNPCDialogue(NPCDialogue);
            UIControl.UIOptions.ChangeInteractionIconToTalk();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("InteractionPoint"))
        {
            Debug.Log("Fuera Interacción");
            CharacterController.characterController.EarseNPCDialogue();
            UIControl.UIOptions.ChangeInteractionIconToCross();
        }
    }
}

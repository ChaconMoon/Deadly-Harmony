using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    bool isCharacterNear;
    bool canInteract = true;
    public Transform destiny;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Dentro Teleporter");
            UIControl.UIOptions.ChangeInteractionActionToDoor();
            isCharacterNear = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Fuera Teleporter");
            UIControl.UIOptions.ChangeInteractionIconToCross();
            isCharacterNear = false;
        }
    }
    private void Update()
    {
        if (CharacterMove.characterOptions.isInteractive && isCharacterNear && canInteract)
        {
            canInteract = false;
            CharacterMove.characterOptions.gameObject.transform.position = destiny.position;
            CharacterMove.characterOptions.partnerMove.gameObject.transform.position = destiny.position - new Vector3(0,1,0);
            canInteract = true;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControl : MonoBehaviour
{
    [Header("InteractionIcon")]
    public Image interactionIconObject;
    public Sprite interactionIconCross;
    public Sprite interactionIconTalk;
    public Sprite interactionIconInteract;
    public Sprite interactionIconPick;
    public Sprite interactionIconDoor;
    [Header("Singleton")]
    public static UIControl UIOptions;
    // Start is called before the first frame update
    void Start()
    {
        UIOptions = this;
    }

    public void ChangeInteractionIconToCross()
    {
        interactionIconObject.sprite = interactionIconCross;
    }
    public void ChangeInteractionIconToTalk()
    {
        interactionIconObject.sprite = interactionIconTalk;
    }
    public void ChangeInteractionActionToInteract()
    {
        interactionIconObject.sprite = interactionIconInteract;
    }
    public void ChangeInteractionActionToPick()
    {
        interactionIconObject.sprite = interactionIconPick;
    }
    public void ChangeInteractionActionToDoor()
    {
        interactionIconObject.sprite = interactionIconDoor;
    }
}

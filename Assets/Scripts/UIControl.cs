using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControl : MonoBehaviour
{
    [Header("InteractionIcon")]
    public Image interactionIconObject;
    public Sprite interactionIconCross;
    public Sprite interactionIconActivate;
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
    public void ChangeInteractionIconToActivate()
    {
        interactionIconObject.sprite = interactionIconActivate;
    }
}

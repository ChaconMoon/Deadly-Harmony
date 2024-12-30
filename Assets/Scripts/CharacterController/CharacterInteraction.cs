using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// The Controller of the interaction area that the character use to interact with other items
/// </summary>
public class CharacterInteraction : MonoBehaviour
{
    /// <summary>
    /// The reference to the object of the interaction point
    /// </summary>
    [Header("Objects")]
    public GameObject interactionPoint;

    /// <summary>
    /// This vector is the distance between the character and the interaction point
    /// </summary>
    private Vector2 delayCharacter;
    
    /// <summary>
    /// This is the reference to the character controller
    /// </summary>
    private CharacterController characterMove;

    /// <summary>
    /// The Update method move the interaction point as well as the character
    /// </summary>
    void Update()
    {
        delayCharacter = characterMove.GetMoves();
        if (delayCharacter != Vector2.zero)
        {
            interactionPoint.transform.position = new Vector2(transform.position.x + delayCharacter.x, transform.position.y + delayCharacter.y);
        }
    }
    /// <summary>
    /// The starts sets the reference to the character controller
    /// </summary>
    private void Start()
    {
        characterMove = GetComponent<CharacterController>();
    }
}

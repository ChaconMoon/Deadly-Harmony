using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInteraction : MonoBehaviour
{
    [Header("Objects")]
    public GameObject interactionPoint;
    private Vector2 delayCharacter;
    private CharacterMove characterMove;

    // Update is called once per frame
    void Update()
    {
        delayCharacter = characterMove.GetMoves();
        if (delayCharacter != Vector2.zero)
        {
            interactionPoint.transform.position = new Vector2(transform.position.x + delayCharacter.x, transform.position.y + delayCharacter.y);
        }
    }
    private void Start()
    {
        characterMove = GetComponent<CharacterMove>();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Dialogue : ScriptableObject
{
    [Header("Info")]
    public InfoCharacter infoCharacterLeft;
    public InfoCharacter infoCharacterRight;
    public string dialogueText;
    public WhoIsTalking whoIsTalking;
    [Header("DialogueImage")]
    public int numberImageLeft;
    public int numberImageRight;

    public Sprite ReturnSpriteLeft()
    {
        return infoCharacterLeft.infoSpritesPersonajesLeft[numberImageLeft].sprite;
    }

    public Sprite ReturnSpriteRight()
    {
        return infoCharacterRight.infoSpritesPersonajesRight[numberImageRight].sprite;
    }
}
public enum WhoIsTalking
{
    Left,Right,
}
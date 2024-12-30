using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// This class contain the information of one dialogue
/// </summary>
[CreateAssetMenu]
public class Dialogue : ScriptableObject
{

    // Set the Characters in the Dialogue

    /// <summary>
    /// The reference to the character at the left of the dialogue
    /// </summary>
    [Header("Info")]
    public InfoCharacter infoCharacterLeft;

    /// <summary>
    /// The reference to the character at the left of the dialogue
    /// </summary>
    public InfoCharacter infoCharacterRight;

    /// <summary>
    /// Set who the characters is talking
    /// </summary>
    public WhoIsTalking whoIsTalking;

    /// <summary>
    /// Set who the character images use the character on the left
    /// </summary>
    [Header("DialogueImage")]
    public int numberImageLeft;

    /// <summary>
    /// Set who the character images use the character on the right
    /// </summary>
    public int numberImageRight;

    /// <summary>
    /// Set if this dialogo have evets
    /// </summary>
    [Header("Events")]
    public bool hasEvents;

    /// <summary>
    /// Set the type of event
    /// </summary>
    public EventType eventType;

    /// <summary>
    /// Set the character to add
    /// </summary>
    public InfoCharacter characterToAdd;

    /// <summary>
    /// Set the item to add
    /// </summary>
    public InfoItem itemToAdd;

    /// <summary>
    /// Set the next conversation
    /// </summary>
    public DialogueContent nextDialogueToShow;

    /// <summary>
    /// set the camera to that position
    /// </summary>
    public string newCameraPosition;

    /// <summary>
    /// Set the achivement that the user get of the dialogue
    /// </summary>
    public Achievement achivementToGet;

    /// <summary>
    /// Set the music of this dialogue
    /// </summary>
    public AudioClip dialogueAudio;

    /// <summary>
    /// Set the animation that achivate this dialogue
    /// </summary>
    public string animationName;

    /// <summary>
    /// Get the sprite of the character at the left
    /// </summary>
    /// <returns>The sprite of the character at the right</returns>
    public Sprite ReturnSpriteLeft()
    {
        return infoCharacterLeft.infoSpritesPersonajesLeft[numberImageLeft].sprite;
    }

    /// <summary>
    /// Get the sprite of the character at the right
    /// </summary>
    /// <returns>The sprite of the character at the right</returns>
    public Sprite ReturnSpriteRight()
    {
        return infoCharacterRight.infoSpritesPersonajesRight[numberImageRight].sprite;
    }
}

/// <summary>
/// The Enum that define who character talk
/// </summary>
public enum WhoIsTalking
{
    Left,Right,
}

/// <summary>
/// The Event Types of the dialogues of the game
/// </summary>
public enum EventType
{
    AddCharacterInMenu,AddObjectInMenu,
    UnlockDialogue, ShowNextDialogue,
    MoveCamera,MoveCameraToResetPosition,ShowAchivement,
    PlayMusic,PlayEffect,RestartBackGroundMusic,Narrator,PlayAnimation,
    None
}
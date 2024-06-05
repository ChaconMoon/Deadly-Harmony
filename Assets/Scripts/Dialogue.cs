using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu]
public class Dialogue : ScriptableObject
{

    //Define la forma en la que se almacenan los dialogos

    [Header("Info")]
    public InfoCharacter infoCharacterLeft;
    public InfoCharacter infoCharacterRight;
    public WhoIsTalking whoIsTalking;

    //Determina de las imagenes de ese personaje cual usa en ese dialogo.
    [Header("DialogueImage")]
    public int numberImageLeft;
    public int numberImageRight;


    [Header("Events")]
    public bool hasEvents;
    public EventType eventType;
    public InfoCharacter characterToAdd;
    public InfoItem itemToAdd;

    //La siguiente conversacion a la que salta al terminar esta.
    public DialogueContent nextDialogueToShow;

    //Se pone el nombre de la posicion a la que se coloca la camara (Se ejecuta antes).
    public string newCameraPosition;

    //Logro que obtienes
    public Achivement achivementToGet;

    //Si quieres cambiar la musica o efecto
    public AudioClip dialogueAudio;

    public string animationName;
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
public enum EventType
{
    AddCharacterInMenu,AddObjectInMenu,
    UnlockDialogue, ShowNextDialogue,
    MoveCamera,MoveCameraToResetPosition,ShowAchivement,
    PlayMusic,PlayEffect,RestartBackGroundMusic,Narrator,PlayAnimation,
    None
}
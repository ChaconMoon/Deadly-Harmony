using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class InfoCharacter : ScriptableObject
{
    //Fichero que define la forma en la que se almacenan los personajes.
    [SerializeField]
    public string characterNameInDialogues;
    public string characterNameInMenu;
    public string characterDescription;
    public Sprite characterIconInMenu;
    public InfoSpritesPersonajes[] infoSpritesPersonajesLeft = new InfoSpritesPersonajes[3];
    public InfoSpritesPersonajes[] infoSpritesPersonajesRight = new InfoSpritesPersonajes[3];
}


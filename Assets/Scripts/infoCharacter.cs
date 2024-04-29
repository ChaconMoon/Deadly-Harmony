using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class InfoCharacter : ScriptableObject
{

    [SerializeField]
    public string characterName;
    public string characterDescription;
    public InfoSpritesPersonajes[] infoSpritesPersonajesLeft = new InfoSpritesPersonajes[3];
    public InfoSpritesPersonajes[] infoSpritesPersonajesRight = new InfoSpritesPersonajes[3];
}


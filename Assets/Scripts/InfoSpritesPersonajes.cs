using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu]
public class InfoSpritesPersonajes : ScriptableObject
{
    // Define la forma en la que se almacenan la informacion de los sprites
    [SerializeField]
    public string spriteName;
    public Sprite sprite;
}

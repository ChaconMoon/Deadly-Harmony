using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu]
public class InfoSpritesPersonajes : ScriptableObject
{
    [SerializeField]
    public string spriteName;
    public Sprite sprite;
}

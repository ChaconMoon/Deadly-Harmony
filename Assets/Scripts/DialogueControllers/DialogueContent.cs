using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A DialogueContent contain a array of the Dialogues in a conversation,
/// is a ScriptableObject that Unity use to content the Game dialogues
/// </summary>
/// 
[CreateAssetMenu]
public class DialogueContent : ScriptableObject
{
    public Dialogue[] dialogues;

}


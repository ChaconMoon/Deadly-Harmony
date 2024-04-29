using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class DialogueOptions : ScriptableObject 
{
    public string[] dialogueTitle = new string[4];
    public DialogueContent[] dialogues = new DialogueContent[4];
    public bool[] activateDialogues = new bool[4];
    
}


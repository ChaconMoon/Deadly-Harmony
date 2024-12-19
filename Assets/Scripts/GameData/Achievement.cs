using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class Achievement : ScriptableObject
{
    [Header("AchievementInfo")]
    public Sprite achievementImage;
    public string achievementName;
    public string achievementDescription;
    
}

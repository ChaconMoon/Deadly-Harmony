using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This class is a ScriptableObject that contain the info of the achievement assets
/// </summary>
[CreateAssetMenu]
public class Achievement : ScriptableObject
{
    /// <summary>
    /// The icon of the achievement in the UI
    /// </summary>
    [Header("AchievementInfo")]
    public Sprite achievementImage;
    /// <summary>
    /// The name of the achievement
    /// </summary>
    public string achievementName;
    /// <summary>
    /// The description of the achievement
    /// </summary>
    public string achievementDescription;
    
}

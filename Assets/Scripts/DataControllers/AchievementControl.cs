using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Define the method that check the achievement is the achievement record
/// </summary>
public class AchievementControl : MonoBehaviour
{
    /// <summary>
    /// The Singleton object of the class
    /// </summary>
    [Header("Singleton")]
    public static AchievementControl instance;

    /// <summary>
    /// The achievement that will been check
    /// </summary>
    [Header("ActualArchivement")]
    private Achievement actualAchievement;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    /// <summary>
    /// Validate if a Achievement is in the record
    /// </summary>
    /// <param name="achievementToShow"></param>
    public void ValidateAchievement(Achievement achievementToShow)
    {
        if (AchievementRecord.achievementRecord.AddToRecord(actualAchievement))
        {
            AchievementUI.achievementUIControl.SetAchievementInUI(achievementToShow);
        }
    }

    
}

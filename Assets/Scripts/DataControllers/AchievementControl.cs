using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AchievementControl : MonoBehaviour
{

    [Header("Singleton")]
    public static AchievementControl instance;

    [Header("ActualArchivement")]
    private Achievement actualAchievement;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    public void ValidateAchievement(Achievement achievementToShow)
    {
        if (AchievementRecord.achievementRecord.AddToRecord(actualAchievement))
        {
            AchievementUI.achievementUIControl.SetAchievementInUI(achievementToShow);
        }
    }

    
}

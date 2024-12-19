using System.Collections.Generic;
using UnityEngine;

public sealed class AchievementRecord: MonoBehaviour
{
    [Header("Register")]
    public static List<Achievement> achievementRegister;
    
    [Header("Singleton")]
    public static AchievementRecord achievementRecord;

    private void Awake()
    {
        achievementRegister = new List<Achievement>();
        achievementRecord = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public bool AddToRecord(Achievement newAchievement)
    {
        foreach (var achievement in achievementRegister)
        {
            if (achievement == newAchievement || achievement == null)
            {
                return false;
            }
        }
        achievementRegister.Add(newAchievement);
        return true;
    }
}

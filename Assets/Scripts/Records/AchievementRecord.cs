using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This class contain the achievement record
/// </summary>
public sealed class AchievementRecord: MonoBehaviour
{
    /// <summary>
    /// The list that cointain the record of the achievements
    /// </summary>
    [Header("Register")]
    private static List<Achievement> achievementRegister;
    
    /// <summary>
    /// The Singleton object that other objects use to get the record
    /// </summary>
    [Header("Singleton")]
    public static AchievementRecord achievementRecord;

    private void Awake()
    {
        achievementRegister = new List<Achievement>();
        achievementRecord = this;
    }

    /// <summary>
    /// Check if the achievement it in the record and and it if is not in it
    /// </summary>
    /// <param name="newAchievement">The new achievement to add</param>
    /// <returns>If it's add to the record</returns>
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

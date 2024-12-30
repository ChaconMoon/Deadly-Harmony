using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
/// <summary>
/// This class interact with the UI of the achievement
/// </summary>
public class AchievementUI : MonoBehaviour
{
    /// <summary>
    /// The Singleton object of this class
    /// </summary>
    [Header("Singleton")]
    public static AchievementUI achievementUIControl;

    /// <summary>
    /// The Animator component of this object
    /// </summary>
    [SerializeField]
    private Animator animatorOfImageAchievement;

    /// <summary>
    /// The audio clip that sound when the player get a achievement
    /// </summary>
    [SerializeField]
    private AudioClip achievementAudio;

    /// <summary>
    /// The space of the achievement icon in the UI
    /// </summary>
    [Header("UI Components")]
    [SerializeField]
    private RawImage spriteAchievement;

    /// <summary>
    /// The UI text that contain the achievement title
    /// </summary>
    [SerializeField]
    private TextMeshProUGUI achievementTitle;

    /// <summary>
    /// The UI text that contain the achievement description
    /// </summary>
    [SerializeField]
    private TextMeshProUGUI achievementDescription;

    private void Awake() {
        achievementUIControl = this;
    }

    /// <summary>
    /// Execute the animation of the achievement UI
    /// </summary>
    public IEnumerator ShowAchievementAnimation() {
        yield return new WaitForSeconds(1f);
        Debug.Log("StartAchievementAnimation");
        animatorOfImageAchievement.Play("AchievementAnimation");
        yield return new WaitForSeconds(0.2f);
        JukeboxEffects.instance.PlayEffect(achievementAudio);
    }
    /// <summary>
    /// Change the info of the achievement in the UI
    /// </summary>
    /// <param name="achievementToShow">The achievement that will be in the UI</param>
    public void SetAchievementInUI(Achievement achievementToShow) {
            Debug.Log("Achievement Show");
            spriteAchievement.texture = achievementToShow.achievementImage.texture;
            achievementTitle.text = achievementToShow.achievementName;
            achievementDescription.text = achievementToShow.achievementDescription;

            StartCoroutine(AchievementUI.achievementUIControl.ShowAchievementAnimation());
    }
}

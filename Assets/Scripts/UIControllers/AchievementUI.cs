using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class AchievementUI : MonoBehaviour
{
    public static AchievementUI achievementUIControl;

    public Animator animatorOfImageAchievement;
    public AudioClip achievementAudio;

    [Header("Components")]
    public RawImage spriteAchievement;
    public TextMeshProUGUI achievementTitle;
    public TextMeshProUGUI achievementDescription;

    private void Awake() {
        achievementUIControl = this;
    }
    public IEnumerator ShowAchievementAnimation() {
        yield return new WaitForSeconds(1f);
        Debug.Log("StartAchievementAnimation");
        animatorOfImageAchievement.Play("AchievementAnimation");
        yield return new WaitForSeconds(0.2f);
        JukeboxEffects.instance.PlayEffect(achievementAudio);
    }
    public void SetAchievementInUI(Achievement achievementToShow) {
            Debug.Log("Achievement Show");
            spriteAchievement.texture = achievementToShow.achievementImage.texture;
            achievementTitle.text = achievementToShow.achievementName;
            achievementDescription.text = achievementToShow.achievementDescription;

            StartCoroutine(AchievementUI.achievementUIControl.ShowAchievementAnimation());
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AchivementControl : MonoBehaviour
{
    [Header("Singleton")]
    public static AchivementControl instance;

    [Header("ActualAchivement")]
    private Achivement actualAchivement;
    [Header("Components")]
    public RawImage spriteAchivement;
    public TextMeshProUGUI achivementTitle;
    public TextMeshProUGUI achivementDescription;
    public Animator animatorOfImageAchivement;
    public AudioClip achivementAudio;

    [Header("Register")]
    public List<Achivement> achivementRegister;
    // Start is called before the first frame update
    void Start()
    {
        achivementRegister = new List<Achivement>();
        // Debug AchiveMent
        //ShowAchivement(actualAchivement);
        instance = this;
    }

    public void ShowAchivement(Achivement achivementToShow)
    {
        Debug.Log("Achivement Show");
        actualAchivement = achivementToShow;
        spriteAchivement.texture = actualAchivement.achivementImage.texture;
        achivementTitle.text = actualAchivement.achivementName;
        achivementDescription.text = actualAchivement.achivementDescription;
        if (CheckAchivementRegister())
        {
            StartCoroutine(ShowAchivementAnimation());
        }
    }
    public IEnumerator ShowAchivementAnimation()
    {
        yield return new WaitForSeconds(1f);
        Debug.Log("StartAchivementAnimation");
        animatorOfImageAchivement.Play("AchivementAnimation");
        yield return new WaitForSeconds(0.2f);
        JukeboxEffects.instance.PlayEffect(achivementAudio);
    }

    public bool CheckAchivementRegister()
    {
        foreach (var achivement in achivementRegister)
        {
            if (achivement == actualAchivement ||achivement==null)
            {
                return false;
            }
        }
        achivementRegister.Add(actualAchivement);
        return true;
    }
}

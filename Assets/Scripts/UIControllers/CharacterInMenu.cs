using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterInMenu : MonoBehaviour
{
    [Header("Datos")]
    public InfoCharacter characterInIcon;

    [Header("Componets")]
    public RawImage rawImage;

    [Header("Variables")]
    public bool inUse;

    [Header("ChacterInfoMenu")]
    public GameObject infoCharacterInMenus;
    public GameObject characterImage;
    private RawImage characterImageSprite;
    public GameObject characterName;
    private TextMeshProUGUI characterNameInText;
    public GameObject characterDescriprion;
    private TextMeshProUGUI characterDescriptionText;


    // Start is called before the first frame update
    void Start()
    {
        if (characterInIcon == null)
        {
            rawImage.texture = CharacterInMenuControl.instance.defaultIcon.texture;
        }
        characterImageSprite = characterImage.GetComponent<RawImage>();
        characterDescriptionText = characterDescriprion.GetComponent<TextMeshProUGUI>();
        characterNameInText = characterName.GetComponent<TextMeshProUGUI>();

    }
    public void UpdateIcon()
    {
        rawImage.texture = characterInIcon.characterIconInMenu.texture;
    }
    public void SetCharacter(InfoCharacter newCharacter)
    {
        characterInIcon = newCharacter;
        Debug.Log(characterInIcon.characterNameInMenu);
        UpdateIcon();
    }
    public void ShowCharacterDescription()
    {
        if (inUse)
        {
            CharacterInMenuControl.instance.HideCharacterIcons();
            infoCharacterInMenus.SetActive(true);
            characterImage.SetActive(true);
            characterName.SetActive(true);
            characterDescriprion.SetActive(true);
            characterImageSprite.texture = characterInIcon.characterIconInMenu.texture;
            characterNameInText.text = characterInIcon.characterNameInMenu;
            characterDescriptionText.text = characterInIcon.characterDescription;
        }
    }

}

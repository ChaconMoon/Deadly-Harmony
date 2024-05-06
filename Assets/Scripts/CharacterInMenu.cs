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
    public GameObject InfoCharacterInMenus;
    public GameObject CharacterImage;
    private RawImage CharacterImageSprite;
    public GameObject CharacterName;
    private TextMeshProUGUI characterNameInText;
    public GameObject CharacterDescriprion;
    private TextMeshProUGUI characterDescriptionText;


    // Start is called before the first frame update
    void Start()
    {
        rawImage = GetComponent<RawImage>();
        if (characterInIcon == null)
        {
            rawImage.texture = CharacterInMenuControl.instance.defaultIcon.texture;
        }
        CharacterImageSprite = CharacterImage.GetComponent<RawImage>();
        characterDescriptionText = CharacterDescriprion.GetComponent<TextMeshProUGUI>();
        characterNameInText = CharacterName.GetComponent<TextMeshProUGUI>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateIcon()
    {
        rawImage.texture = characterInIcon.characterIconInMenu.texture;
    }
    public void SetCharacter(InfoCharacter newCharacter)
    {
        characterInIcon = newCharacter;
        UpdateIcon();
    }
    public void ShowCharacterDescription()
    {
        if (inUse)
        {
            CharacterInMenuControl.instance.HideCharacterIcons();
            InfoCharacterInMenus.SetActive(true);
            CharacterImage.SetActive(true);
            CharacterName.SetActive(true);
            CharacterDescriprion.SetActive(true);
            CharacterImageSprite.texture = characterInIcon.characterIconInMenu.texture;
            characterNameInText.text = characterInIcon.characterName;
            characterDescriptionText.text = characterInIcon.characterDescription;
        }
    }

}

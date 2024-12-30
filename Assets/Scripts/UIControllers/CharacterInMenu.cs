using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// This class interact with the UI that containts the info of one the character
/// </summary>
public class CharacterInMenu : MonoBehaviour
{
    /// <summary>
    /// The info of the character in this item
    /// </summary>
    [Header("Datos")]
    public InfoCharacter characterInIcon;

    /// <summary>
    /// The Raw Image in the UI that contain the image of the character in this item
    /// </summary>
    [Header("Componets")]
    public RawImage rawImage;

    /// <summary>
    /// Define if this item is in use
    /// </summary>
    [Header("Variables")]
    public bool inUse;

    /// <summary>
    /// The referense to the base object that show this item
    /// </summary>
    [Header("ChacterInfoMenu")]
    public GameObject infoCharacterInMenus;

    /// <summary>
    /// The reference to the object with the character imagen in UI
    /// </summary>
    public GameObject characterImage;

    /// <summary>
    /// The reference to the space of the character image component in IU
    /// </summary>
    private RawImage characterImageSprite;

    /// <summary>
    /// The reference to the space of the object with the character image
    /// </summary>
    public GameObject characterName;

    /// <summary>
    /// The reference to the UI text component with the character name
    /// </summary>
    private TextMeshProUGUI characterNameInText;
    
    /// <summary>
    /// The reference to the object with the character description
    /// </summary>
    public GameObject characterDescriprion;
    
    /// <summary>
    /// The reference to the UI text component with character description
    /// </summary>
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

    /// <summary>
    /// Set thee icon in the menu of characters
    /// </summary>
    public void UpdateIcon()
    {
        rawImage.texture = characterInIcon.characterIconInMenu.texture;
    }

    /// <summary>
    /// Set the charcter in the menu
    /// </summary>
    /// <param name="newCharacter">The new character to add to the menu</param>
    public void SetCharacter(InfoCharacter newCharacter)
    {
        characterInIcon = newCharacter;
        Debug.Log(characterInIcon.characterNameInMenu);
        UpdateIcon();
    }
    /// <summary>
    /// Shows the description of a character in the menu
    /// </summary>
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

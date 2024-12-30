using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class is the controller of the info of the character in the menu
/// </summary>
public class CharacterInMenuControl : MonoBehaviour
{
    /// <summary>
    /// Is the instance of the singleton object of this class
    /// </summary>
    [Header("Singleton")]
    public static CharacterInMenuControl instance;

    /// <summary>
    /// The list of the characters in the menu
    /// </summary>
    [Header("CharacterIcons")]
    public CharacterInMenu[] charactersInMenu;

    /// <summary>
    /// The reference to the default icon in the character menu
    /// </summary>
    [Header("DefaultIcon")]
    public Sprite defaultIcon;

    /// <summary>
    /// The reference to the individual character icon in the menu
    /// </summary>
    [Header("GameObjects Containers")]
    public GameObject CharacterIcons;

    /// <summary>
    /// The reference to the individual character description in the menu
    /// </summary>
    public GameObject CharacterDescription;

    
    void Awake()
    {
        instance = this;
    }

    /// <summary>
    /// Add a character to the characters menu
    /// </summary>
    /// <param name="characterToAdd">The character to add</param>
    public void AddCharacterInIcon(InfoCharacter characterToAdd)
    {
        bool characterWasAdded = false;
        for (int i = 0; i < charactersInMenu.Length; i++)
        {
            if (charactersInMenu[i].characterInIcon != null)
            {
                if (characterToAdd.characterNameInDialogues == charactersInMenu[i].characterInIcon.characterNameInDialogues)
                {
                    characterWasAdded = true;
                }
            }
            if (!charactersInMenu[i].inUse & !characterWasAdded)
            {
                charactersInMenu[i].inUse = true;
                charactersInMenu[i].SetCharacter(characterToAdd);
                characterWasAdded = true;
            }
        }
    }

    /// <summary>
    /// Open the characters menu and clase de character description menu
    /// </summary>
    public void HideChacterInfo()
    {
        CharacterIcons.SetActive(true);
        CharacterDescription.SetActive(false);
    }

    /// <summary>
    /// Hide the characters icons in the menu
    /// </summary>
    public void HideCharacterIcons()
    {
        CharacterIcons.SetActive(false);
    }

    /// <summary>
    /// check if the character to add is in the record and add it
    /// </summary>
    /// <param name="characterToAdd">The character to add</param>
    /// <returns>The result of the operation</returns>
    public bool IsCharacterAdded(InfoCharacter characterToAdd)
    {

        for (int i = 0; i < charactersInMenu.Length; i++)
        {
            if (charactersInMenu[i].characterInIcon != null)
            {
                if (characterToAdd.characterNameInDialogues == charactersInMenu[i].characterInIcon.characterNameInDialogues)
                {
                    return true;
                }
            }
        }
        return false;
    }
}

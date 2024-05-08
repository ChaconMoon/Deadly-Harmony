using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInMenuControl : MonoBehaviour
{
    [Header("Singleton")]
    public static CharacterInMenuControl instance;
    [Header("CharacterIcons")]
    public CharacterInMenu[] charactersInMenu;

    [Header("DefaultIcon")]
    public Sprite defaultIcon;

    [Header("GameObjects Containers")]
    public GameObject CharacterIcons;
    public GameObject CharacterDescription;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddCharacterInIcon(InfoCharacter characterToAdd)
    {
        bool characterWasAdded = false;
        for (int i = 0; i < charactersInMenu.Length; i++)
        {
            if (charactersInMenu[i].characterInIcon != null)
            {
                if (characterToAdd.characterName == charactersInMenu[i].characterInIcon.characterName)
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
    public void HideChacterInfo()
    {
        CharacterIcons.SetActive(true);
        CharacterDescription.SetActive(false);
    }
    public void HideCharacterIcons()
    {
        CharacterIcons.SetActive(false);
    }

    public bool IsCharacterAdded(InfoCharacter characterToAdd)
    {

        for (int i = 0; i < charactersInMenu.Length; i++)
        {
            if (charactersInMenu[i].characterInIcon != null)
            {
                if (characterToAdd.characterName == charactersInMenu[i].characterInIcon.characterName)
                {
                    return true;
                }
            }
        }
        return false;
    }
}

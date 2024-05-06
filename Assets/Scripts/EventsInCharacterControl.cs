using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsInCharacterControl : MonoBehaviour
{
    [Header("EventObjects")]
    public GameObject CharacterMenu;
    private CharacterInMenuControl characterInMenuControl;
    // Start is called before the first frame update
    void Start()
    {
        CharacterMenu = GameObject.FindGameObjectWithTag("CharacterMenu");
        characterInMenuControl = CharacterMenu.GetComponent<CharacterInMenuControl>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void addCharacterToMenu(InfoCharacter charactertoAdd)
    {
        characterInMenuControl.AddCharacterInIcon(charactertoAdd);
    }
}

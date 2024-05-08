using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MenuControl : MonoBehaviour
{
    [Header("Secciones del menu")]
    public GameObject menuPersonajes;
    public GameObject menuPruebas;
    public GameObject contenidoMenu;

    [Header("Variables")]
    public bool isMenuOpen;

    [Header("Singleton")]
    public static MenuControl instance;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        
    }
    private void Start()
    {
        menuPersonajes.SetActive(false);
        contenidoMenu.SetActive(false);
        menuPruebas.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenMenu()
    {
        contenidoMenu.SetActive(true);
        menuPruebas.SetActive(true);
        menuPersonajes.SetActive(false);
        isMenuOpen = true;
    }
    public void CloseMenu()
    {
        contenidoMenu.SetActive(false);
        menuPruebas.SetActive(false);
        menuPersonajes?.SetActive(false);
        isMenuOpen=false;
    }
    public void AbrirMenuPruebas()
    {
        menuPruebas.SetActive(true);
        menuPersonajes.SetActive(false);
    }
    public void AbrirMenuPersonajes()
    {
        menuPersonajes.SetActive(true);
        menuPruebas.SetActive(false);
    }
    public void OpenCloseMenu()
    {
        Debug.Log("Menu Abierto");
        if (isMenuOpen)
        {
            CloseMenu();
        }
        else
        {
            OpenMenu();
        }
    }

}

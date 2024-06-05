using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInMenuControl : MonoBehaviour
{
    [Header("Singleton")]
    public static ItemInMenuControl instance;

    [Header("ItemIcons")]
    public ItemInMenu[] itemsInMenu;

    [Header("DefaultItemIcon")]
    public Sprite defaultIcon;

    [Header("GameObject Containers")]
    public GameObject itemIcons;
    public GameObject itemDescription;

    [Header("Items Getted Variable")]
    public bool boodBodyWasGetted;
    public bool neckMarksWasGetted;
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddItemInIcon(InfoItem itemtoAdd)
    {
        bool itemWasAdded = false;
        for (int i = 0; i < itemsInMenu.Length; i++)
        {
            if (itemsInMenu[i].itemInIcon != null)
            {
                if (itemtoAdd.itemKey == itemsInMenu[i].itemInIcon.itemKey)
                {
                    itemWasAdded = true;
                }
            }
            if (!itemsInMenu[i].inUse & !itemWasAdded)
            {
                ChangeItemVariable(itemtoAdd);
                itemsInMenu[i].inUse = true;
                itemsInMenu[i].SetItem(itemtoAdd);
                itemWasAdded = true;
            }
        }
    }
    public void HideItemInfo()
    {
        itemIcons.SetActive(true);
        itemDescription.SetActive(false);
    }
    public void HideItemIcons() {

        itemIcons.SetActive(false);

    }

    public bool IsItemAdded(InfoItem itemToadd)
    {
        for (int i = 0;i < itemsInMenu.Length; i++)
        {
            if (itemsInMenu[i].itemInIcon != null)
            {
                if (itemToadd.itemKey == itemsInMenu[i].itemInIcon.itemKey)
                {
                    return true;
                }
            }
        }
        return false;
    }
    public void ChangeItemVariable(InfoItem item)
    {
        switch (item.itemKey)
        {
            case "BODY_BLOOD":
                boodBodyWasGetted = true;
                break;
            case "BODY_MARKS":
                neckMarksWasGetted = true;
                break;

        }
    }
}

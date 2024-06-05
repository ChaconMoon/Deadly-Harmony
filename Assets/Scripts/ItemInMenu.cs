using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemInMenu : MonoBehaviour
{
    [Header("Datos")]
    public InfoItem itemInIcon;

    [Header("Components")]
    public RawImage rawImage;

    [Header("Variables")]
    public bool inUse;

    [Header("ItemInfoMenu")]
    public GameObject infoItemInMenus;
    public GameObject itemImage;
    private RawImage itemImageSprite;
    public GameObject itemName;
    private TextMeshProUGUI itemNameInText;
    public GameObject itemDescription;
    private TextMeshProUGUI itemDescriptionText;
    // Start is called before the first frame update
    void Start()
    {
        if (itemInIcon == null)
        {
            rawImage.texture = ItemInMenuControl.instance.defaultIcon.texture;
        }
        itemImageSprite = itemImage.GetComponent<RawImage>();
        itemDescriptionText = itemDescription.GetComponent<TextMeshProUGUI>();
        itemNameInText = itemName.GetComponent<TextMeshProUGUI>();
    }
    
    public void UpdateIcon()
    {
        rawImage.texture = itemInIcon.itemImage.texture;
    }
    public void SetItem(InfoItem newItem)
    {
        itemInIcon = newItem;
        Debug.Log(itemInIcon.itemName);
        UpdateIcon();
    }
    public void ShowItemDescription()
    {
        if (inUse)
        {
            ItemInMenuControl.instance.HideItemIcons();
            infoItemInMenus.SetActive(true);
            itemImage.SetActive(true);
            itemName.SetActive(true);
            itemDescription.SetActive(true);
            itemImageSprite.texture = itemInIcon.itemImage.texture;
            itemNameInText.text = itemInIcon.itemName;
            itemDescriptionText.text = itemInIcon.itemDescription;
        }
    }
}

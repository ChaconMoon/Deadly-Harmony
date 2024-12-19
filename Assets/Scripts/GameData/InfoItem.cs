using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class InfoItem : ScriptableObject
{
    [Header("InternalUse")]
    public string itemKey;

    [Header("ItemInfo")]
    public string itemName;
    public string itemDescription;
    public Sprite itemImage;

}

/*
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour
{
    public Image iconImage;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI typeText;

    public ItemSO itemSO;

    public void InitItem(ItemSO itemSO)
    {
        string type = "";
        switch (itemSO.itemType)
        {
            case ItemType.Weapon:
                type = "����"; break;
            case ItemType.Consumable:
                type = "������Ʒ"; break;
        }

        iconImage.sprite = itemSO.icon;
        nameText.text = itemSO.name;
        typeText.text = type;
        this.itemSO = itemSO;
    }

    public void OnClick()
    {
        InventoryUI.Instance.OnItemClick(itemSO,this);
    }
}
*/

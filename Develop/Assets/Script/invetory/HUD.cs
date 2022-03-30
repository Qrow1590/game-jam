using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour
{
    public Inventory Inventory;

    void Start()
    {
        Inventory.ItemAdded += InventoryScript_ItemAdded;
    }

    public void InventoryScript_ItemAdded(object sender, InventoryEventArgs e)
    {
        Transform inventoryPanel = transform.Find("InventoryPanel");
        foreach(Transform slot in inventoryPanel)
        {
            Image image = slot.GetChild(0).GetComponent<Image>(); 
            if (!image.enable)
            {
                image.enable = true;
                image.sprite = e.Tem.Image;

                break;
            }
        }

    }

}

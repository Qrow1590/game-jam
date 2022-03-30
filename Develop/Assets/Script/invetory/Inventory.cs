using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Inventory : MonoBehaviour
{
    private const int Slots = 6;
    private List<IInventoryItem> mItems = new List<IInventoryItem>();
 
    public event EventHandler<IInventoryEventArgs> ItemAdded;
    
    public void AddItem(IInventoryItem item)
    {
        if(mItems.Count < Slots)
        {
            Collider collider = (item as MonoBehaviour).GetComponent<Collider>();
            if (collider.enable)
            {
                collider.enable = false;
                mItems.Add(item);
                item.OnPickup();

                if (ItemAdded != null)
                {
                    ItemAdded(this, new IInventoryEventArgs(item));
                }
            }
        }
    }



}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Inventory : MonoBehaviour
{
    [SerializeField] private GameObject inventory;
    [SerializeField] private Transform container;
    private Dictionary<string, int> list = new Dictionary<string, int>();
    private Dictionary<string, GameObject> UIlist = new Dictionary<string, GameObject>(); // make this string, GameObject to make it easier to destroy

    public void addInventory(string name, bool visibleGift)
    {
        if (list.ContainsKey(name))
        {
            int value = list[name];
            list[name] = value + 1;
            if(visibleGift){
            UIlist[name].GetComponent<TextMeshProUGUI>().text = name + " x " + list[name];
            }
        }
        else
        {
            list.Add(name, 1);
            if(visibleGift){
            UIlist.Add(name, Instantiate(inventory, container));
            UIlist[name].GetComponent<TextMeshProUGUI>().text = name + " x 1";
            }
        };
    }

    public bool containsItem(string name)
    {
        return list.ContainsKey(name);
    }

    public void removeItem(string[] arr, bool takeGift)
    {
        if(takeGift){
        for (int i = 0; i < arr.Length; i++)
        {
            if (UIlist.ContainsKey(arr[i]))
            {
                Destroy(UIlist[arr[i]]);
                UIlist.Remove(arr[i]);
            }
        }
    }
    }

}

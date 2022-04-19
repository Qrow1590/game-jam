using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Inventory : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI inventory;
    [SerializeField] private Transform container;
    private Dictionary<string, int> list = new Dictionary<string, int>();
    private Dictionary<string, TextMeshProUGUI> UIlist = new Dictionary<string, TextMeshProUGUI>();

    public void addInventory(string name){
        if(list.ContainsKey(name)){
            int value = list[name];
            list[name] = value + 1;
            UIlist[name].text = name + " x " + list[name];
        }else{
            list.Add(name, 1);
            UIlist.Add(name, Instantiate(inventory, container));
            UIlist[name].text = name + " x 1";
        };       
    }

}

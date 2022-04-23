using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class QuestList : MonoBehaviour
{
    [SerializeField] private GameObject questList;
    [SerializeField] private Transform container;
    // private Dictionary<string, int> list = new Dictionary<string, int>();
    private Dictionary<string, GameObject> UIlist = new Dictionary<string, GameObject>(); // make this string, GameObject to make it easier to destroy

    public void addQuest (string name, string quest)
    {
        if (UIlist.ContainsKey(name))
        {
            return;
        }else
        {
            UIlist.Add(name, Instantiate(questList,container));
            UIlist[name].GetComponent<TextMeshProUGUI>().text = quest;
        }
    
    }

    public void removeQuest(string name)
    {
            if (UIlist.ContainsKey(name)){
                Destroy(UIlist[name]);
                UIlist.Remove(name);
            }
    }

}

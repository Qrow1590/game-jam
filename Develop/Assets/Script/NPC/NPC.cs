using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class NPC : MonoBehaviour
{
    private Control cont;
    private int talk = 0;
    private int index1 = 0;
    private int index2 = 0;
    [SerializeField] private NPCStats stats;
    [SerializeField] private TextMeshProUGUI dialouge;
    [SerializeField] private GameObject textBox;
    [SerializeField] private Queue<string> intro = new Queue<string>();
    [SerializeField] private string[] reminder = null;
    [SerializeField] private string[] ending = null;
    [SerializeField] private Inventory backpack;
    [SerializeField] private QuestList quest;

    private void Awake()
    {
        cont = new Control();
        for (int i = 0; i < stats.intro.Length; i++)
        {
            intro.Enqueue(stats.intro[i]);
        }
        reminder = stats.reminder;
        ending = stats.ending;
    }

    private void OnEnable()
    {
        cont.Enable();
    }

    private void OnDisable()
    {
        cont.Interact.Disable();
        cont.Interact.Interact.Disable();
    }
    public bool Dialouge()
    {
        textBox.SetActive(true);
        if (talk == 0)
        {
            quest.addQuest(gameObject.name, stats.questBlurb);
            
            return Intro(intro);
        } else if (talk > 0 && !isQuestComplete())
        {
            return Reminder(reminder);
        } else if (talk > 0 && isQuestComplete()){
            
            var end =  Conclusion(ending);
            if(talk == 1){
                quest.removeQuest(gameObject.name);
                backpack.addInventory(stats.gift[0], stats.visibleGift);
                backpack.removeItem(stats.requirement, stats.takeGift);
            }
            talk++;
            return end;
        }
        return false;
    }

    private bool Intro(Queue<string> queue)
    {
        if (queue.Count > 0)
        {
            dialouge.text = queue.Dequeue();
            return false;
        } else {
            talk++;
            textBox.SetActive(false);
            index1=0;
            return true;
        }
    }
    private bool Reminder(string[] arr)
    {
        if(index1 < arr.Length){
        dialouge.text = arr[index1];
        index1++;
        return false;
        } else {
            textBox.SetActive(false);
            index1 = 0;
            return true;
        }
    }

    private bool Conclusion(string[] arr){
        if(index2 < arr.Length){
            dialouge.text = arr[index2];
            index2++;
            return false;
        } else {
            textBox.SetActive(false);
            index2 = 0;
            return true;
        }
    }

    private bool isQuestComplete(){
        var req = stats.requirement;
        for(int i = 0 ; i < req.Length; i++){
            if(!backpack.containsItem(req[i])){
            return false;
            }
        }
        return true;
    }
}

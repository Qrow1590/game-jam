using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class NPC : MonoBehaviour
{
    private Control cont;
    private int talk = 0;
    private int index = 0;
    [SerializeField] private NPCStats stats;
    [SerializeField] private TextMeshProUGUI dialouge;
    [SerializeField] private GameObject textBox;
    [SerializeField] private Queue<string> intro = new Queue<string>();
    [SerializeField] private string[] reminder = null;

    private void Awake()
    {
        cont = new Control();
        for (int i = 0; i < stats.intro.Length; i++)
        {
            intro.Enqueue(stats.intro[i]);
        }
        reminder = stats.reminder;
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
            return Intro(intro);
        } else if (talk > 0)
        {
            return Reminder(reminder);
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
            index=0;
            return true;
        }
    }
    private bool Reminder(string[] arr)
    {
        if(index < arr.Length){
        dialouge.text = arr[index];
        index++;
        return false;
        } else {
            textBox.SetActive(false);
            index = 0;
            return true;
        }
    }
}

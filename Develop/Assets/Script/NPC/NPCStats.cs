using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "NPCStats", menuName = "Develop/NPCStats", order = 0)]
public class NPCStats : ScriptableObject {
    public string[] intro;
    public string[] reminder;
    public string[] ending;

    public string questBlurb;
    public bool complete;
    public bool visibleGift;
    public bool takeGift;
    public string[] requirement;
    public string[] gift;
}


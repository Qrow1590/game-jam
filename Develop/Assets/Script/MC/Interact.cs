using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interact : MonoBehaviour
{
    // keep track of what interaction is happening 
    // pause player movement and rotation while the player is seeing somethig
        private Control cont;
        [SerializeField] private Collider trigger;
        [SerializeField] private Inventory backpack;
        [SerializeField] private Movement move;
    void Awake(){
        cont = new Control();
    }

    private void OnEnable(){
        cont.Enable();
        cont.Interact.Interact.performed += _ =>TriggerSwitch(true);
        cont.Interact.Interact.canceled += _ => TriggerSwitch(false);
    }

    private void TriggerSwitch(bool state) {
        trigger.enabled = state ;
    }

    private void OnDisable(){
        cont.Interact.Disable();
        cont.Interact.Interact.Disable();
    }
    void OnTriggerEnter(Collider other) {
        if (other.tag == "NPC"){
           bool isDone = other.GetComponent<NPC>().Dialouge();
           if(!isDone){ // stop the player from moving while dialouge is happening
               move.enabled = false;
           } else {
               move.enabled = true;
           }
        }
         if (other.tag == "Item") {
            backpack.addInventory(other.name);
            other.gameObject.SetActive(false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class NPC : MonoBehaviour
{
    private Control cont;
    private int talk = 0;
    [SerializeField] private NPCStats stats;
    [SerializeField] private TextMeshProUGUI dialouge;
    [SerializeField] private GameObject textBox;
    private void Awake(){
        cont = new Control();
    }

    private void OnEnable(){
        cont.Enable();
    }

    private void OnDisable(){
        cont.Interact.Disable();
        cont.Interact.Interact.Disable();
    }
    private void OnTriggerEnter(Collider other) {
        
        if(other.gameObject.tag == "Player"){
            textBox.SetActive(true);
            if(talk == 0){
            StartCoroutine(Dialouge(stats.intro));
            }
            if(talk > 0) {
            StartCoroutine(Dialouge(stats.reminder));
            }
        }
    }

   private void OnTriggerExit(Collider other) {
        talk++; 
    }

    private IEnumerator Dialouge(string[] arr)
    {   
        dialouge.text = arr[0];
        yield return new WaitForSeconds(2f);
        for(int i = 1; i < arr.Length ; i++){
                yield return new WaitForSeconds(2f);
                dialouge.text = arr[i];
            }
            yield return new WaitForSeconds(1f);
            textBox.SetActive(false);
    }
}

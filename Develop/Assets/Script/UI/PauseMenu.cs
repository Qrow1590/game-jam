using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PauseMenu : MonoBehaviour
{
    private Control cont;
    [SerializeField] private Menu script;
    [SerializeField] private GameObject pause;

    void Awake(){
        cont = new Control();
    }
    void OnEnable(){
        cont.Enable();
        cont.UI.Enable();
        cont.UI.Pause.performed += _ => openClose();
    }
    
    void OnDisable(){
        cont.UI.Disable();
        cont.Disable();
    }

    private void openClose(){
        if(!pause.activeSelf){
            script.OpenMenu(pause);
        } else {
            script.CloseMenu(pause);
        }
    }
}

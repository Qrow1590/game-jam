using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Questory : MonoBehaviour
{
    private Control cont;
    private int menuCount = 0;
    [SerializeField] private GameObject itemList;
    [SerializeField] private GameObject questList;

    void Awake()
    {
        cont = new Control();
        cont.Enable();    
        cont.UI.Menus.Enable();
        cont.UI.Menus.performed += _ => MenuOpen();
    }
    private void OnEnable()
    {
        cont.Enable();
        menuCount = 0;
        cont.UI.Menus.Enable();
    }

    private void MenuOpen(){
        if(menuCount == 0){
            itemList.SetActive(true);
            menuCount = menuCount + 1;
        } else if (menuCount == 1){
            itemList.SetActive(false);
            questList.SetActive(true);
            menuCount = menuCount + 1;
        } else if (menuCount == 2){
            itemList.SetActive(false);
            questList.SetActive(false);
            menuCount = 0;
        }
    }

    private void OnDisable()
    {
        cont.UI.Menus.Disable();
        cont.UI.Disable();
    }
}

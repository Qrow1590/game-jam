using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
    GameObject openMenu;
    public void OpenMenu(GameObject menu){
        openMenu = menu;
        menu.SetActive(true);
    }

    public void CloseMenu(){
        openMenu.SetActive(false);
        openMenu = null;
    }

    public void Play(){
        SceneManager.LoadScene(1);
    }

    public void Quit(){
        Application.Quit();
    }
}

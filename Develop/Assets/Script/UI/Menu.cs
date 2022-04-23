using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
    void Awake(){
        Cursor.lockState = CursorLockMode.None;
   
    }
    public void OpenMenu(GameObject menu){
        menu.SetActive(true);
    }



    public void CloseMenu(GameObject menu){
        menu.SetActive(false);
    }

    public void Play(){
        SceneManager.LoadScene(1);
    }

    public void Quit(){
        Application.Quit();
    }
    public void returnMain(){
        SceneManager.LoadScene(0);
    }


}

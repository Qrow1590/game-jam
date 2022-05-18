using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneTransition : MonoBehaviour
{
    public void onWin(){
        StartCoroutine(transTime()); // could us a string to differentiate the scenes transitioned
    }

    private IEnumerator transTime(){
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("WinScene");
    }
    
}

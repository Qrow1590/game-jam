using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneTransition : MonoBehaviour
{
    [SerializeField]
    private Animator SceneTransit;
    [SerializeField]
    private GameObject SceneTransitObject;
    [SerializeField]
    private PauseMenu script;
    // freeze other scripts
    public void onWin(){
        StartCoroutine(transTime("LoadOut")); // could use a string to differentiate the scenes transitioned
    }

    private IEnumerator transTime(string Animation){
        yield return new WaitForSeconds(1f); // find a way to trigger this after the final line is siad
        script.disableInteractions();
        SceneTransitObject.SetActive(true);
        SceneTransit.Play(Animation);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("WinScene");
    }
    
}

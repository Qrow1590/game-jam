using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PauseMenu : MonoBehaviour
{
    private Control cont;
    [SerializeField] private Menu script;
    [SerializeField] private GameObject pause;


    [SerializeField] private Interact interact;
    [SerializeField] private Questory questory;
    [SerializeField] private Movement movement;


    void Awake()
    {
        cont = new Control();
    }
    void OnEnable()
    {
        cont.Enable();
        cont.UI.Enable();
        cont.UI.Pause.performed += _ => openClose();
    }

    void OnDisable()
    {
        cont.UI.Pause.performed -= _ => openClose();
        cont.UI.Disable();
        cont.Disable();
    }

    private void openClose()
    {
        if (!pause.activeSelf)
        {
            script.OpenMenu(pause);
            disableInteractions();
        }
        else
        {
            script.CloseMenu(pause);
            enableInteractions();
        }
    }

    public void disableInteractions()
    {
        questory.enabled = false;
        interact.enabled = false;
        movement.enabled = false;
    }

    public void enableInteractions()
    {
        interact.enabled = true;
        movement.enabled = true;
        questory.enabled = true;
    }
}

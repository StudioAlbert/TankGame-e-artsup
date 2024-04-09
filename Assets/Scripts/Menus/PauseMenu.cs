using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PauseMenu : MonoBehaviour
{

    [SerializeField] private UIDocument _pauseMenu;
    
    private void Start()
    {
        VisualElement _root = _pauseMenu.rootVisualElement;
        
        Button buttonResume = _root.Q<Button>("ResumeBtn");
        if(buttonResume is not null)
        {
            buttonResume.RegisterCallback<ClickEvent>(OnClickedResume);
        }
        
        Button buttonMainMenu = _root.Q<Button>("MainMenuBtn");
        if(buttonMainMenu is not null)
        {
            buttonMainMenu.RegisterCallback<ClickEvent>(OnClickedMain);
        }
        
        ExitPause();
        
    }

    private void OnClickedMain(ClickEvent evt)
    {
        Debug.Log("Main");
        SceneManager.LoadScene("MainMenu");
    }

    private void OnClickedResume(ClickEvent evt)
    {
        Debug.Log("Resume");
        ExitPause();
    }


    private void OnPause(InputValue value)
    {
        
        Debug.Log("Pause Input");
        
        if (_pauseMenu.gameObject.activeSelf)
        {
            // Plus la pause
            ExitPause();
        }
        else
        {
            // C'est la pause
            EnterPause();
        }
    }

    private void EnterPause()
    {
        _pauseMenu.gameObject.SetActive(true);
        Time.timeScale = 0F;
    }

    private void ExitPause()
    {
        _pauseMenu.gameObject.SetActive(false);
        Time.timeScale = 1F;
    }

}

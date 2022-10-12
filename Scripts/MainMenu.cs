﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string newGameScene;

    public GameObject continueButton;

    public string loadGameScene;

    public bool isNewGame = false;
    public static MainMenu instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        if (PlayerPrefs.HasKey("Current_Scene"))
        {
            continueButton.SetActive(true);
        }
        else
        {
            continueButton.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Continue()
    {
        SceneManager.LoadScene(loadGameScene);
    }

    public void NewGame()
    {
        isNewGame = true;
        SceneManager.LoadScene(newGameScene);
        
    }

    public void Exit()
    {
        Application.Quit();
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PageController : MonoBehaviour
{
    public bool isEscapeToExit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (isEscapeToExit)
            {
                Application.Quit();
            }
            else
            {
                ReturnMenu();
            }
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Main");
    }

    public void ReturnMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}

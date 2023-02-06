using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public List<Button> buttons;

    private void Start()
    {
        
    }
    public void Update()
    {
        if (LevelManager.instance != null)
        {
            for (int i = 0; i < buttons.Count; i++)
            {
                if (LevelManager.instance.levelCompleted[i] == true)
                {
                    buttons[i].interactable = true;
                }
                else
                {
                    buttons[i].interactable = false;
                }
            }
        }
            
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu; // ќб'Їкт меню паузи

    private void Start()
    {
        pauseMenu.SetActive(false); // ¬имикаЇмо меню паузи на початку
    }
    private void Update()
    {
        // якщо натиснута клав≥ша Escape,
        // то в≥дкриваЇмо або закриваЇмо меню паузи
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // якщо меню паузи вже в≥дкрите,
            // то закриваЇмо його ≥ в≥дновлюЇмо час
            if (pauseMenu.activeSelf == true)
            {
                // ¬имикаЇмо меню паузи
                pauseMenu.SetActive(false);
                // ¬≥дновлюЇмо час
                Time.timeScale = 1.0f;
            }
            else if (pauseMenu.activeSelf == false)
            {
                pauseMenu.SetActive(true);
                Time.timeScale = 0f;
            }
        }
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Esc_Menu : MonoBehaviour
{
    public GameObject escMenu;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            escMenu.SetActive(!escMenu.activeSelf);
        }
    }
    public void ReturnButton()
    {
        escMenu.SetActive(!escMenu.activeSelf);
    }
    public void EscButton()
    {
        Application.Quit();
    }
}

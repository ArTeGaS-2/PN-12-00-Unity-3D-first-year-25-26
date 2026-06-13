using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSwitch : MonoBehaviour
{
    public GameObject gameObjFolder; // Папка з об'єктами гри
    public GameObject UIGameObjFolder; // Папка UI об'єктів гри

    public GameObject shopObjFolder; // Папка з об'єктами магазину
    public GameObject UIShopObjFolder; // Папка UI об'єктів магазину

    public void SS_Button()
    {
        gameObjFolder.SetActive(!gameObjFolder.activeSelf);
        UIGameObjFolder.SetActive(!UIGameObjFolder.activeSelf);

        shopObjFolder.SetActive(!shopObjFolder.activeSelf);
        UIShopObjFolder.SetActive(!UIShopObjFolder.activeSelf);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Controler : MonoBehaviour
{
    public GameObject sidePanel; // Панель вибору веж
    public GameObject insideTowerCoice; // Панель обраної вежі

    private void Awake()
    {
        sidePanel.SetActive(true); // Панель вибору активна
        insideTowerCoice.SetActive(false); // конкретна вежа ні
    }

    public void GoInsideTowerChoice()
    {
        sidePanel.SetActive(false);
        insideTowerCoice.SetActive(true);
    }

    public void BackToSidePanel()
    {
        sidePanel.SetActive(true);
        insideTowerCoice.SetActive(false);
    }
}

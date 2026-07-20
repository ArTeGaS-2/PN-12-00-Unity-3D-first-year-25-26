using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Controler : MonoBehaviour
{
    public static UI_Controler Instance;

    public GameObject sidePanel; // Панель вибору веж
    public GameObject insideTowerCoice; // Панель обраної вежі
    public GameObject openSidePanelButton; // Відкрити бокову панель

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        DontDestroyOnLoad(gameObject);

        sidePanel.SetActive(false); 
        insideTowerCoice.SetActive(false);

        openSidePanelButton.SetActive(true);
    }

    public void OpenTowerPanel()
    {
        sidePanel.SetActive(false);
        insideTowerCoice.SetActive(true);
        openSidePanelButton.SetActive(false);
    }

    public void OpenSidePanel()
    {
        sidePanel.SetActive(true);
        insideTowerCoice.SetActive(false);
        openSidePanelButton.SetActive(false);
    }
    public void ClosePanels()
    {
        insideTowerCoice.SetActive(false);
        sidePanel.SetActive(false);
        openSidePanelButton.SetActive(true);
    }
}

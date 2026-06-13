using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Counter : MonoBehaviour
{
    public static Counter Instance; // Сінглтон

    public TextMeshProUGUI counter; // Об'єкт лічильника
    public string counterText = "Рахунок: "; // Текст в лічильнику
    public int counterNum = 0; // Число в лічильнику
    private void Start()
    {
        Instance = this;
    }
    public void EarnPoint()
    {
        // +1 до лічильника
        counterNum++;
        // Оновлюємо текст на екрані
        counter.text = counterText + counterNum.ToString();
    }
}

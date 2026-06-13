using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecoRandomizer : MonoBehaviour
{
    public int chanceToSpawn = 50; // Шанс створити об'єкт декорації

    private void Start()
    {
        gameObject.SetActive(false); // Деактивуємо на початку
        int randomNum = Random.Range(0, 100); // Випадкове число

        if (randomNum < chanceToSpawn) // Якщо число менше за шанс
        {
            gameObject.SetActive(true); // Активуємо
        }
    }
}

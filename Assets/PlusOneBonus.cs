using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlusOneBonus : MonoBehaviour
{
    private Economy economy;
    private void Start()
    {
        economy = Economy.Instance;
    }
    public void PlusOneBonusButton()
    {
        // Поточна кількість "монет" більша, або дорівнює ціні бонусу
        if (economy.clickCounter >= economy.TakeCurrentPrice())
        {
            economy.clickCounter -= economy.TakeCurrentPrice(); // Заплатили
            economy.UpdateCounterText(); // Оновили текст лічильника
            economy.coinsPerClick++; // Додали +1 за клік

            Economy.Instance.UpdatePerClickText();
            Economy.Instance.UpdatePerClickPriceText();
        }
    }
    private void OnMouseDown()
    {
        PlusOneBonusButton();
    }
}

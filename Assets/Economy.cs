using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Economy : MonoBehaviour
{
    public static Economy Instance;

    [Header("Лічильник та ін.")]
    public float clickCounter = 0; // Змінна лічильника
    public int coinsPerClick = 1; // Валюти за клік

    [Header("Бонус до кліку")]
    public float clickBonusPrice = 10f; // Ціна за покращення(Базова)
    public float clickBonusPriceMod = 15f; // Модифікатор ціни

    [Header("Бонус до авто-кліку")]
    public float coinsPerAutoClick = 0f; // Валюти за період часу
    public float autoClickBonusPrice = 25f; // ціна авто-кліку (базовий)
    public float autoClickBonusPriceMod = 50f; // модифікатор

    [Header("Об'єкти на сцені")]
    public TextMeshProUGUI counterText; // Текст лічильника
    public TextMeshProUGUI coinsPerClickText; // Текст кількості монет за клік
    public TextMeshProUGUI clickBonusPriceText; // Текст поточної ціни
    public TextMeshProUGUI autoClickSecText; // Скільки авто-кліків за сек.
    public TextMeshProUGUI autoClickSecPriceText; // Ціна авто-кліку

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        UpdatePerClickText();
        UpdatePerClickPriceText();
    }
    public float TakeCurrentPrice()
    {
        // поточнаЦіна = базова ціна + (монетЗаКлік - 1) * модифікатоЦіни
        float price =
            clickBonusPrice + (coinsPerClick - 1) * clickBonusPriceMod;
        return price;
    }
    public float TakeCurrentAutoPrice()
    {
        // поточнаЦіна = базова ціна + (монетЗаКлік - 1) * модифікатоЦіни
        float price =
            autoClickBonusPrice + (coinsPerAutoClick - 1
            ) * autoClickBonusPriceMod;
        return price;
    }

    public void UpdateCounterText()
    {
        counterText.text = "Монет: " + clickCounter.ToString();
    }
    public void UpdatePerClickText()
    {
        coinsPerClickText.text = $"+ {coinsPerClick} за клік";
    }
    public void UpdatePerClickPriceText()
    {
        clickBonusPriceText.text = $"Ціна за бонус: {TakeCurrentPrice()}";
    }
    public void UpdatePerAutoClickText()
    {
        autoClickSecText.text = $"+ {coinsPerAutoClick} за клік";
    }
    public void UpdatePerAutoClickPriceText()
    {
        autoClickSecPriceText.text = $"Ціна за бонус: {TakeCurrentAutoPrice()}";
    }
}

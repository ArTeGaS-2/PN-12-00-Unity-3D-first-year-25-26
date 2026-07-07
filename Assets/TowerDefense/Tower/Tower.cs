using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [Header("Об'єкти")]
    [SerializeField] GameObject projectilePrefab; // Шаблон снаряду
    [SerializeField] GameObject spawnPoint; // Точка спавну снаряду

    [Header("Параметри вежі")]
    [SerializeField] float attackInterval = 1f; // Інтервал між атаками
    [SerializeField] float attackDamage = 1f; // Шкода від атаки
    [SerializeField] float attackRadius = 5f; // Радіус атаки вежі

    private List<GameObject> enemiesList; // Вороги в зоні досяжності пострілу

    private bool enemiesInRadius = false; // Чи є вороги в радіусі атаки
    private Coroutine towerAttack; // Посилання на корутину атаки вежі

    private void Awake()
    {
        enemiesList = new List<GameObject>();
    }

    private void Start()
    {
        // StartCoroutine(ProjectileSpawnCycle());
        towerAttack = null;
    } 
    private IEnumerator ProjectileSpawnCycle()
    {
        while (true)
        {
            // Очищуємо список від мертвих чи неіснуючих ворогів
            enemiesList.RemoveAll(enemy => enemy == null);

            // Якщо список пустий
            if (enemiesList.Count == 0)
            {
                towerAttack = null; // Очищуємо змінну що зберігає атаку
                yield break; // Зупиняємо цикл атаки
            }

            // Мішень - перший ворого у списку
            GameObject target = enemiesList[0];
            
            Projectile projectile = Instantiate( // Зберігаємо об'єкт в змінну
                projectilePrefab, // посилання на шаблон
                spawnPoint.transform.position, // позиція спавну
                Quaternion.identity).GetComponent<Projectile>(); // обертання

            projectile.target = target;
            
            yield return new WaitForSecondsRealtime(attackInterval); // Затримка
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            if (towerAttack == null)
            {
                towerAttack = StartCoroutine(ProjectileSpawnCycle());
            }
            enemiesList.Add(other.gameObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy")) // Перевірка тегу
        {
            // Якщо вороги відсутні
            if (enemiesList.Count == 0 && towerAttack != null)
            {
                // Зупинка корутіни пострілу
                StopCoroutine(towerAttack);
            }
            // Видалення ворога зі списку
            enemiesList.Remove(other.gameObject);
        }
    }
    public void OnEnemyDeath(GameObject enemy)
    {
        if (enemiesList.Count == 0)
        {
            StopCoroutine(towerAttack);
        }
        enemiesList.Remove(enemy);
    }
}

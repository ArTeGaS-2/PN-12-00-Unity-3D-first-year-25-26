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
            if (enemiesList.Count > 0 && enemiesList[0] == null)
            {
                OnEnemyDeath(enemiesList[0]);
            }
            if (enemiesList.Count > 0)
            {
                Projectile projectile = Instantiate( // Зберігаємо об'єкт в змінну
                    projectilePrefab, // посилання на шаблон
                    spawnPoint.transform.position, // позиція спавну
                    Quaternion.identity).GetComponent<Projectile>(); // обертання

                projectile.target = enemiesList[0];
            }
            
            yield return new WaitForSecondsRealtime(attackInterval); // Затримка
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Засік ворога по тегу");
            if (enemiesList.Count == 0)
            {
                Debug.Log("Ворогів було нуль, починаю стріляти");
                towerAttack = StartCoroutine(ProjectileSpawnCycle());
            }
            enemiesList.Add(other.gameObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            if (enemiesList.Count == 0)
            {
                StopCoroutine(towerAttack);
            }
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAgent : MonoBehaviour
{
    [SerializeField] string targetName; // Назва цілі на сцені
    [SerializeField] float enemyMaxHP = 20f; // Максимальне здоров'я ворога
    [SerializeField] float enemyDamage = 5f; // Сила атаки ворога
     
    private float enemyCurrentHP; // Поточне здоров'я ворога
    private NavMeshAgent agent; // Компонент NavMeshAgent для руху ворога

    private void Start()
    {
        enemyCurrentHP = enemyMaxHP; // Ініціалізуємо поточне здоров'я ворога
        agent = GetComponent<NavMeshAgent>(); // Отримуємо компонент NavMeshAgent

        agent.SetDestination(
            GameObject.Find(targetName // Знаходимо об'єкт з назвою targetName
            ).transform.position); // Встановлюємо ціль для руху ворога
    }
    public void TakeDamage(float damage)
    {
        if (enemyCurrentHP > 0) // Поточне ХП більше нуля
        {
            if (enemyCurrentHP >= damage) // нанесено DMG не більше ніж є
            {
                enemyCurrentHP -= damage;
            }
            else
            {
                Destroy(gameObject);
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}

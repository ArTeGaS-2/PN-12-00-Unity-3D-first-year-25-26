using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPreviewColor : MonoBehaviour
{
    [SerializeField] private Color blockedColor =
        new Color(1f, 0f, 0f, 0.19f); // Червоний колір
    private Renderer[] renderers; // Список матеріалів об'єктів перешкод
    private Color[] originalColors; // Оригінальні кольори цих об'єктів
    private int obstacleContacts; // Кількість перешкод з якими зіштовхнулись

    private void Awake()
    {
        renderers = GetComponentsInChildren<Renderer>();
        originalColors = new Color[renderers.Length];
        
        for (int i = 0; i < renderers.Length; i++)
        {
            originalColors[i] = renderers[i].material.color;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Obstacle")) return;
        obstacleContacts++;
        SetColor(blockedColor);
    }
    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Obstacle")) return;
        obstacleContacts = Mathf.Max(0, obstacleContacts - 1);
        if (obstacleContacts == 0) RestoreColors();
    }
    private void SetColor(Color color)
    {
        foreach (Renderer currentRenderer in renderers)
        {
            currentRenderer.material.color = color;
        }
    }
    private void RestoreColors()
    {
        for (int i = 0; i < renderers.Length; i++)
        {
            renderers[i].material.color = originalColors[i];
        }
    }
}

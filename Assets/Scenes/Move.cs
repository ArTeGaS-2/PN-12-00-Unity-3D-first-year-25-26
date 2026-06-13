using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private void Update()
    {
        // Натискання "A" для руху вліво
        if (Input.GetKey(KeyCode.A))
        {
            // Рух на певну кількість юнітів
            transform.Translate(-10f * Time.deltaTime, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            // Рух на певну кількість юнітів
            transform.Translate(10f * Time.deltaTime, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.W))
        {
            // Рух на певну кількість юнітів
            transform.Translate(0f, 0f, 10f * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            // Рух на певну кількість юнітів
            transform.Translate(0f, 0f, -10f * Time.deltaTime);
        }
    }
}

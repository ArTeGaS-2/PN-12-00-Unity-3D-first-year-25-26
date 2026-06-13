using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Controller : MonoBehaviour
{
    public GameObject camera; 
    private Rigidbody rb; // фізичний компонент

    public float jumpVelocity = 5f; // сила стрибка

    [Header("Режим блювоти")]
    public float rotateSpeed = 0f;
    public bool vomMode = false;

    [Header("Кути обертання персонажа")]
    public float upAngle = -30f; // Кут під'йому в гору
    public float downAngle = 20f; // Кут падіння в низ

    [Header("Параметри плавного обертання")]
    public float rotationSpeed = 8f; // Швидкість обертання
    private float targetXAngle; // Цільовий кут по осі X

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        if (vomMode)
        {
            camera.transform.Rotate(
            0f, 0f, rotateSpeed * Time.fixedDeltaTime);
        }
    }

    private void Update()
    {
        // Стрибок
        if (Input.GetKeyDown(KeyCode.Space) ||
            Input.GetMouseButtonDown(0))
        {
            rb.AddForce(Vector3.up * jumpVelocity,
                ForceMode.Impulse);
        }
        ApplyInputAngle();
        ApplySmoothRotate();

    }
    private void LateUpdate()
    {
        camera.transform.position = new Vector3(
            camera.transform.position.x,
            transform.position.y,
            camera.transform.position.z);
    }
    private void OnCollisionEnter(Collision collision)
    {
        SceneManager.LoadScene(1);
    }
    private void ApplyInputAngle()
    {
        if (Input.GetKeyDown(KeyCode.Space) ||
            Input.GetMouseButtonDown(0))
        {
            targetXAngle = upAngle;
        }
        else if (Input.GetKeyUp(KeyCode.Space) ||
                 Input.GetMouseButtonUp(0))
        {
            targetXAngle = downAngle;
        }
    }
    private void ApplySmoothRotate()
    {
        // Встановлює цільове обертання у тимчасову змінну - targetRot
        Quaternion targetRot = Quaternion.Euler(targetXAngle, 0, 0);
        // До поточного кута обертання застосовується плавне обертання
        transform.rotation = Quaternion.Lerp(
            transform.rotation,             // Поточний кут
            targetRot,                      // Цільовий кут
            rotationSpeed * Time.deltaTime);// Час за який обертаємо
    }
}

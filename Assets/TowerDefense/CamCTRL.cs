using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamCTRL : MonoBehaviour
{
    [Header("Швидкість")]
    [SerializeField] float moveSpeed = 10f; // швидкість руху
    [SerializeField] float zoomSpeed = 10f; // швидкість зуму

    [Header("Ліміти зуму")]
    [SerializeField] float minZoomDistance = 30f; // Мін відстань
    [SerializeField] float maxZoomDistance = 120f; // Макс відстань

    [Header("Ліміти руху")]
    [SerializeField] float horizontalBorder = 20f; // Лівий та правий кордон
    [SerializeField] float verticalBorder = 20f; // Верхній та нижній кордон

    private Vector3 initialPosition; // Початкова позиція камери
    private Vector3 positionLimits; // Межі руху камери

    private void Start()
    {
        // Зберігаємо початкову позицію камери
        initialPosition = transform.position;
        // Встановлюємо межі руху камери
        positionLimits = new Vector3(
            horizontalBorder,
            transform.position.y,
            verticalBorder);
    }

    private void FixedUpdate()
    {
        MoveCamera();
        ZoomCamera();
    }
    private void MoveCamera()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        transform.position = new Vector3(
            transform.position.x + horizontal * moveSpeed * Time.fixedDeltaTime,
            transform.position.y,
            transform.position.z + vertical * moveSpeed * Time.fixedDeltaTime);

        transform.position = new Vector3(
            
            Mathf.Clamp(
                transform.position.x, // 0
                initialPosition.x - positionLimits.x, // 0 - 20
                initialPosition.x + positionLimits.x), // 0 + 20

            transform.position.y,

            Mathf.Clamp(
                transform.position.z, // 0
                initialPosition.z - positionLimits.z, // 0 - 20
                initialPosition.z + positionLimits.z) // 0 + 20
            );
    }
    private void ZoomCamera()
    {
        // Отримуємо значення прокрутки колеса миші
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        // Змінюємо поле зору камери на основі прокрутки та швидкості зуму
        Camera.main.fieldOfView -= scroll * zoomSpeed * Time.fixedDeltaTime;
        // Обмежуємо зум в межах мінімальної та максимальної відстані
        Camera.main.fieldOfView = Mathf.Clamp(
            Camera.main.fieldOfView, // Поле зору
            minZoomDistance, // Мін відстань
            maxZoomDistance); // Макс відстань
    }
}

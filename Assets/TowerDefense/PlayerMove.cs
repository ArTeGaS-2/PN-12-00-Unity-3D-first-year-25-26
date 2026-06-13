using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float playerSpeed = 5f; // Швидкість руху
    [SerializeField] float playerJumpForce = 5f; // Сила стрибка
    Rigidbody rb; // Посилання на фізичний компонент

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        Vector3 moveDirection = new Vector3(
            Input.GetAxis("Horizontal"),
            0,
            Input.GetAxis("Vertical"));
    }
}

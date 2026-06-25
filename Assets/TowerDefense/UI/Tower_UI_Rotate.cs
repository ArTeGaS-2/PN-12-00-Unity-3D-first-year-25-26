using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower_UI_Rotate : MonoBehaviour
{
    public float rotateSpeed = 1;
    private void FixedUpdate()
    {
        transform.Rotate(0f, 0f, rotateSpeed);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipesMove : MonoBehaviour
{
    public float speed = 5f;
    private void FixedUpdate()
    {
        transform.Translate(
            Vector3.back * speed * Time.fixedDeltaTime);
    }
}

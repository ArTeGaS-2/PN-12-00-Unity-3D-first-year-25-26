using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Counter.Instance.EarnPoint();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoClickBonus : MonoBehaviour
{
    public void BuyAutoClick()
    {
        if (Economy.Instance.clickCounter >=
            Economy.Instance.TakeCurrentAutoPrice())
        {
            Economy.Instance.coinsPerAutoClick += 1f;
        }
    }
    private void OnMouseDown()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropMoneyInAmbar : MonoBehaviour
{
    private Money money;

    private void Start()
    {
        money = gameObject.GetComponent<Money>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("AmbarSaleZone"))
        {
            money.DropMoneyAmbar();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VegetablesPickupLogic : MonoBehaviour
{
    private KorzinaTakeLogic korzinaTakeLogic;
    private Money money;

    private void Start()
    {
        money = gameObject.GetComponent<Money>();
        korzinaTakeLogic = gameObject.GetComponent<KorzinaTakeLogic>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(money._balanceInKorzina < money._maxPlayBalance)
        {
            if(other.gameObject.CompareTag("Vegetable"))
            {
                if(korzinaTakeLogic._wasPicked)
                {
                    GameObject vegeetables = other.gameObject;

                    vegeetables.SetActive(false);

                    money.VegetableRewardMoney();
                }
            }

            if(other.gameObject.CompareTag("Soloma"))
            {
                if(korzinaTakeLogic._wasPicked)
                {
                    GameObject soloma = other.gameObject;

                    soloma.SetActive(false);

                    money.PshenicaRewardMoney();
                }
            }
        }
        else if(money._balanceInKorzina == money._maxPlayBalance)
        {
            money.MaxValue();
        }
    }
}

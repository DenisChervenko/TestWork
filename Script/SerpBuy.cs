using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SerpBuy : MonoBehaviour
{
    [SerializeField] private GameObject _serp;
    [SerializeField] private GameObject _serpBuyZone;
    [SerializeField] private GameObject _buyBUtton;

    [SerializeField] private GameObject _pickupButton;

    [SerializeField] private GameObject _sailZoneAmbar;

    KorzinaTakeLogic korzinaTakeLogic;
    ParticelControll particelControll;
    Money money;

    public bool _wasBuyed;

    private void Start()
    {
        _buyBUtton.SetActive(false);
        _sailZoneAmbar.SetActive(false);

        money = gameObject.GetComponent<Money>();
        korzinaTakeLogic = gameObject.GetComponent<KorzinaTakeLogic>();
        particelControll = GameObject.Find("ParticelController").GetComponent<ParticelControll>();
    }

    public void OnClickBuy()
    {
        if(money._balanceInKorzina > 10)
        {
            money.WillBuyedSomething();

            InterfaceChnageVisibility();

            _wasBuyed = true;
            _sailZoneAmbar.SetActive(true);

            particelControll.RoadShow();
        }
    }

    private void InterfaceChnageVisibility()
    {
        _buyBUtton.SetActive(false);
        _pickupButton.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("SerpBuyZone") || other.gameObject.CompareTag("Serp"))
        {
            if(!korzinaTakeLogic._wasPicked)
            {
                if(_wasBuyed)
                {
                    _pickupButton.SetActive(true);
                    _serpBuyZone.SetActive(false);
                }
                else
                {
                    _buyBUtton.SetActive(true);
                }

                particelControll.HideRoad();

            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Serp"))
        {
            if(!korzinaTakeLogic._wasPicked)
            {
                if(_wasBuyed)
                {
                    _pickupButton.SetActive(false);
                }
                else
                {
                    _buyBUtton.SetActive(false);
                }
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KorzinaFillingMoney : MonoBehaviour
{
    [SerializeField] private GameObject _firstMoneyLevel;
    [SerializeField] private GameObject _secondMoneyLevel;
    [SerializeField] private GameObject _thirdMoneyLevel;

    private Money money;

    private void Start()
    {
        money = gameObject.GetComponent<Money>();
    }

    public void MoneyMehsVisibility(ref int level)
    {
        if(level == 0)
        {
            _firstMoneyLevel.SetActive(true);
        }
        else if(level == 1)
        {
            _secondMoneyLevel.SetActive(true);
            _firstMoneyLevel.SetActive(false);
        }
        else
        {
            _thirdMoneyLevel.SetActive(true);
            _secondMoneyLevel.SetActive(false);
        }
    }

    public void DisableAllMoney()
    {
        _firstMoneyLevel.SetActive(false);
        _secondMoneyLevel.SetActive(false);
        _thirdMoneyLevel.SetActive(false);
    }
}

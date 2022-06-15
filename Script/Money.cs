using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Money : MonoBehaviour
{
    [SerializeField] private GameObject _korzina;
    [SerializeField] private TMP_Text _balancePlayer;
    [SerializeField] private TMP_Text _balanceAmbarText;

    [SerializeField] private TMP_Text _maxPlayBalanceText;
    [SerializeField] private TMP_Text _maxAmbarBalanceText;

    [SerializeField] private int _maxAmbarBalance;
    public int _maxPlayBalance;

    public int _balanceInKorzina;
    private int _balanceAmbar;

    private KorzinaFillingMoney korzinaFillingMoney;
    private EndLevelLogic endLevelLogic;
    private ParticelControll particelControll;
    private SerpBuy serpBuy;

    private void Start()
    {
        korzinaFillingMoney = _korzina.GetComponent<KorzinaFillingMoney>();
        endLevelLogic = gameObject.GetComponent<EndLevelLogic>();
        particelControll = GameObject.Find("ParticelController").GetComponent<ParticelControll>();
        serpBuy = gameObject.GetComponent<SerpBuy>();

        _maxPlayBalanceText.text = Convert.ToString(_maxPlayBalance);
        _maxAmbarBalanceText.text = Convert.ToString(_maxAmbarBalance);
    }

    public void VegetableRewardMoney()
    {
        _balanceInKorzina++;
        _balancePlayer.text = Convert.ToString(_balanceInKorzina);

        VisualizeMeshCoin();
    }

    public void PshenicaRewardMoney()
    {
        _balanceInKorzina += 2;
        _balancePlayer.text = Convert.ToString(_balanceInKorzina);

        VisualizeMeshCoin();
    }

    private void VisualizeMeshCoin()
    {
        if(_balanceInKorzina >= 3)
        {
            int turn = 1;
            korzinaFillingMoney.MoneyMehsVisibility(ref turn);
        }
        else if(_balanceInKorzina >= 20)
        {
            int turn = 2;
            korzinaFillingMoney.MoneyMehsVisibility(ref turn);
        }
        else if(_balanceInKorzina >= 30)
        {
            int turn = 3;
            korzinaFillingMoney.MoneyMehsVisibility(ref turn);
        }

        if(_balanceInKorzina == 11)
        {
            particelControll.SerpCanTake();
        }

        if(serpBuy._wasBuyed)
        {
            particelControll.AmbarCanSale();
        }
    }

    public void WillBuyedSomething()
    {
        _balanceInKorzina = 0;
        _balancePlayer.text = Convert.ToString(_balanceInKorzina);
        korzinaFillingMoney.DisableAllMoney();
    }

    public void DropMoneyAmbar()
    {
        _balanceAmbar += _balanceInKorzina;
        korzinaFillingMoney.DisableAllMoney();
        
        if(_balanceAmbar >= _maxAmbarBalance)
        {
            _balanceAmbar = _maxAmbarBalance;

            endLevelLogic.EndLevel();

            Time.timeScale = 0;
        }

        _balanceAmbarText.text = Convert.ToString(_balanceAmbar);

        _balanceInKorzina = 0;
        _balancePlayer.text = Convert.ToString(_balanceInKorzina);

        particelControll.AmbarCantTake();
    }

    public void MaxValue()
    {
        _balanceInKorzina = _maxPlayBalance;
        _balancePlayer.text = Convert.ToString(_balanceInKorzina);
    }
}

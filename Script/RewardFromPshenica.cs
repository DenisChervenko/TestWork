using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardFromPshenica : MonoBehaviour
{
    [SerializeField] private GameObject _rewardObject;

    public void DropReward()
    {
        _rewardObject.SetActive(true);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevelLogic : MonoBehaviour
{
    [SerializeField] private GameObject _endScreen;

    public void EndLevel()
    {
        _endScreen.SetActive(true);
    }
}

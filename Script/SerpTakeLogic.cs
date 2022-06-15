using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SerpTakeLogic : MonoBehaviour
{
    [SerializeField] private Transform _handPlaceForSerp;
    [SerializeField] private GameObject _serp;

    [SerializeField] private GameObject _pickupSerpButton;
    [SerializeField] private GameObject _dropSerpButton;

    public bool _wasPickedSerp;

    ParticelControll particelControll;

    private void Start()
    {
        _pickupSerpButton.SetActive(false);
        _dropSerpButton.SetActive(false);

        particelControll = GameObject.Find("ParticelController").GetComponent<ParticelControll>();
    }

    public void OnClickTakeSerp()
    {
        _serp.transform.position = _handPlaceForSerp.transform.position;
        _serp.transform.SetParent(null);
        _serp.transform.SetParent(_handPlaceForSerp);

        _wasPickedSerp = true;
        _pickupSerpButton.SetActive(false);
        _dropSerpButton.SetActive(true);

        particelControll.SerpAlreadyTaked();
    }

    public void OnClickDropSerp()
    {
        _serp.transform.SetParent(null);

        _wasPickedSerp = false;
        _pickupSerpButton.SetActive(true);
        _dropSerpButton.SetActive(false);
        
        particelControll.SerpCanTake();
    }
}

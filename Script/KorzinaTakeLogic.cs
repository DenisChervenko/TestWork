using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KorzinaTakeLogic : MonoBehaviour
{
    [SerializeField] private GameObject _korzina;
    [SerializeField] private Transform _placeInHandForKorzina;

    [SerializeField] private GameObject _pickupButton;
    [SerializeField] private GameObject _dropButton;

    private Rigidbody _rbKorzina;

    public bool _wasPicked;

    SerpTakeLogic serpTakeLogic;
    ParticelControll particelControll;

    private void Start()
    {
        _rbKorzina = _korzina.GetComponent<Rigidbody>();

        _dropButton.SetActive(false);
        _pickupButton.SetActive(false);

        serpTakeLogic = gameObject.GetComponent<SerpTakeLogic>();
        particelControll = GameObject.Find("ParticelController").GetComponent<ParticelControll>();
    }

    public void OnClickPickup()
    {
        _korzina.transform.position = _placeInHandForKorzina.transform.position;
        _korzina.transform.SetParent(_placeInHandForKorzina);

        _rbKorzina.isKinematic = true;

        _wasPicked = true;
        _pickupButton.SetActive(false);
        _dropButton.SetActive(true);

        particelControll.KorzinaAlreadyTaked();
    }

    public void OnClickDrop()
    {
        _korzina.transform.SetParent(null);

        _rbKorzina.isKinematic = false;

        _wasPicked = false;
        _pickupButton.SetActive(false);
        _dropButton.SetActive(false);

        particelControll.KorzinaCanTake();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Korzina"))
        {
            if(!serpTakeLogic._wasPickedSerp)
            {
                _pickupButton.SetActive(true);
            }
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Korzina"))
        {
            _pickupButton.SetActive(false);
        }
    }

    
}

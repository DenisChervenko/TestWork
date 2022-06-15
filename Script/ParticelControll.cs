using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticelControll : MonoBehaviour
{
    [SerializeField] private ParticleSystem _serp;
    [SerializeField] private ParticleSystem _korzina;
    [SerializeField] private ParticleSystem _ambar;
    [SerializeField] private ParticleSystem _road;

    private void Start()
    {
        _serp.Stop();
        _ambar.Stop();
        _road.Stop();
    }

    public void SerpCanTake() => _serp.Play();
    public void SerpAlreadyTaked() => _serp.Stop();

    public void KorzinaCanTake() => _korzina.Play();
    public void KorzinaAlreadyTaked() => _korzina.Stop();

    public void AmbarCanSale() => _ambar.Play();
    public void AmbarCantTake() => _ambar.Stop();

    public void RoadShow() => _road.Play();
    public void HideRoad() => _road.Stop();
}

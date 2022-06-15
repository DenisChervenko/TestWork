using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPshenicaLogic : MonoBehaviour
{
    [SerializeField] private GameObject _takeNoneHitMesh;
    [SerializeField] private ParticleSystem _particle;
    private GameObject _player;

    [SerializeField] private float _timeBetwenSpawn;

    private bool _willDestroyed;

    private float _elapsedTime;

    private Collider _boxCollider;
    private AttackLogic attackLogic;
    private RewardFromPshenica rewardFromPshenica;

    private void Start()
    {
        _player = GameObject.Find("Player");
        attackLogic = _player.GetComponent<AttackLogic>();
        _boxCollider = gameObject.GetComponent<BoxCollider>();
        rewardFromPshenica = gameObject.GetComponent<RewardFromPshenica>();
    }

    private void Update()
    {
        if(_willDestroyed)
        {
            _elapsedTime += Time.deltaTime;

            if(_elapsedTime >= _timeBetwenSpawn)
            {
                _willDestroyed = false;
                RevivePshenica();
                _elapsedTime = 0;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Serp"))
        {
            if(attackLogic._willAttackNow)
            {
                if(!_willDestroyed)
                {
                    DestroyMesh();
                }
            }
        }
    }

    private void DestroyMesh()
    {
            _takeNoneHitMesh.SetActive(false);
            attackLogic._willAttackNow = true;
            _willDestroyed = true;

            _particle.Play();
            rewardFromPshenica.DropReward();
    }

    private void RevivePshenica()
    {
        _takeNoneHitMesh.SetActive(true);
    }
}

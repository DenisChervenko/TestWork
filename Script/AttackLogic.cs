using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackLogic : MonoBehaviour
{
    public bool _canCallMoveAnimation;
    public bool _willAttackNow;

    SerpTakeLogic serpTakeLogic;

    private void Start()
    {
        _canCallMoveAnimation = true;
        serpTakeLogic = gameObject.GetComponent<SerpTakeLogic>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Pshenica"))
        {
            if(serpTakeLogic._wasPickedSerp)
            {
                AnimationAttack();
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Pshenica"))
        {
            if(serpTakeLogic._wasPickedSerp)
            {
                AnimationAttack();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Pshenica"))
        {
            _canCallMoveAnimation = true;
            _willAttackNow = false;
        }
    }

    private void AnimationAttack()
    {
        _canCallMoveAnimation = false;
        _willAttackNow = true;
    }
}

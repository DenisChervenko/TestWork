using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : SimpleInput
{
    [SerializeField] private float _speed;

    private float _verticalDirection;
    private float _horizontalDirection;

    private Animator _anim;
    private Rigidbody _rb;

    private KorzinaTakeLogic korzinaTakeLogic;
    private AttackLogic attackLogic;

    private void Start()
    {
        _anim = gameObject.GetComponent<Animator>();
        _rb = gameObject.GetComponent<Rigidbody>();

        korzinaTakeLogic = gameObject.GetComponent<KorzinaTakeLogic>();
        attackLogic = gameObject.GetComponent<AttackLogic>();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        _verticalDirection = SimpleInput.GetAxis("Vertical");
        _horizontalDirection = SimpleInput.GetAxis("Horizontal");

        if(_verticalDirection != 0 || _horizontalDirection != 0)
        {
            Vector3 movementDirection = new Vector3(_horizontalDirection * _speed, 0, _verticalDirection * _speed);

            _rb.velocity = movementDirection;
            transform.forward = movementDirection;

            if(attackLogic._canCallMoveAnimation)
            {   
                if(korzinaTakeLogic._wasPicked)
                {
                    _anim.SetTrigger("WalkWithKorzina");
                    
                }
                else
                {
                    _anim.SetTrigger("Walk");
                }
            }
            else
            {
                _anim.SetTrigger("Attack");
            }
        }
        else
        {
            FreezePosition();
        }
    }

    private void FreezePosition()
    {
        if(attackLogic._canCallMoveAnimation)
        {
            if(korzinaTakeLogic._wasPicked)
            {
                _anim.SetTrigger("IdleWithKorzina");
            }
            else
            {
                _anim.SetTrigger("Idle");
            }
        }

        _rb.angularVelocity = Vector3.zero;
        _rb.velocity = Vector3.zero;
    }
}

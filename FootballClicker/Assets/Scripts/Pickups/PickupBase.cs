﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PickupBase : MonoBehaviour
{
    [SerializeField]
    protected float _speed = 4f;
    protected GameObject _player;
    protected bool _collected;
    public virtual void Start()
    {
        _player = FindObjectOfType<BallScript>().gameObject;
        _collected = false;
    }

    public virtual void FixedUpdate()
    {
        if (!_collected)
        {
            transform.position += (Vector3.left * Time.deltaTime) * _speed;
        }
        else
        {
            transform.position = _player.transform.position;
        }
    }

    public abstract void Activate();

    protected virtual void OnMouseDown()
    {
        if (!_collected)
        {
            Ray _raycast;

            //_raycast = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);

            _raycast = Camera.main.ScreenPointToRay(Input.mousePosition);

            _raycast = Camera.main.(Input.mousePosition);
            RaycastHit _raycastHit;
            if (Physics.Raycast(_raycast, out _raycastHit))
            {
                if (_raycastHit.collider.tag == "Pickup")
                {
                    //gameObject.GetComponent<Renderer>().enabled = false;
                    _collected = true;
                    Activate();
                }
            }
        }
    }
}

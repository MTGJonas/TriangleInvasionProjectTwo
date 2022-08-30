using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class BaseMoveForward : MonoBehaviour
{
    [SerializeField] private float _initSpeed = 1f;
    float _movespeed;

    
    protected virtual void Update()
    {
        transform.Translate(Vector3.down * ((_movespeed+GameManager.Instance.BaseSpeed) * Time.deltaTime));
    }

    private void Start() => GameManager.Instance.StateChanged += HandleChangedState;

    private void OnDestroy() => GameManager.Instance.StateChanged += HandleChangedState;
    private void HandleChangedState()
    {
        _movespeed = _initSpeed * GameManager.Instance.BaseSpeed;
    }




}

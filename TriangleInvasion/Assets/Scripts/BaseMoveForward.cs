using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BaseMoveForward : MonoBehaviour
{
    [SerializeField] private float _movespeed = 1f;
    private float _baseSpeed = 1f;

    

    private void Update()
    {
        transform.Translate(Vector3.down * ((_movespeed+_baseSpeed) * Time.deltaTime));
    }


}

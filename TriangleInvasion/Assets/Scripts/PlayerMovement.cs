using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 2;
    [SerializeField]private float _minPos;
    [SerializeField]private float _maxPos;
    
    private float _xPos;
    
    // Update is called once per frame
    void Update()
    {
        var input = Input.GetAxis("Horizontal");

        var movement = input * _speed * Time.deltaTime;
        _xPos += movement;
        _xPos = Mathf.Clamp(_xPos, _minPos, _maxPos);

        var currentYpos = transform.position.y;

        transform.position = new Vector3(_xPos, currentYpos, 0);
    }
}

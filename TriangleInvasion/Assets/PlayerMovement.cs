using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 2;

    // Update is called once per frame
    void Update()
    {
        var input = Input.GetAxis("Horizontal");

        var movement = input * _speed * Time.deltaTime;

        transform.position += Vector3.right * movement;
    }
}

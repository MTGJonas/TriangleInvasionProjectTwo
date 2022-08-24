using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveForward : MonoBehaviour, ITakeDamage
{
    [SerializeField] private float _movespeed = 1f;
    [SerializeField] private float _baseSpeed = 1f;

    public void TakeDamage()
    {
        gameObject.SetActive(false);
    }

    private void Update()
    {
        transform.Translate(Vector3.down * (_movespeed+ * Time.deltaTime));
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Projectile _projectile;
    [SerializeField] Transform _firePoint;
    [SerializeField] float _fireRate;
    
    float _nextFireTime = 0;
    bool canFire { get { return Time.time > _nextFireTime; } }

    public void TryFire()
    {

        if (canFire)
        {
            Instantiate(_projectile,_firePoint.position,Quaternion.identity);
            _nextFireTime = Time.time + _fireRate;
        }

    }
}


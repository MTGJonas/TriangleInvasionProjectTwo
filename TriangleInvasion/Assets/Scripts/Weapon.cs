using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Projectile _projectile;
    [SerializeField] List<Transform> _firePoint;
    [SerializeField] float _fireRate;
    
    float _nextFireTime = 0;
    bool canFire { get { return Time.time > _nextFireTime; } }

    public void TryFire()
    {

        if (canFire)
        {
            foreach(Transform t in _firePoint)
            {
                Instantiate(_projectile, t.position, t.rotation);
                _nextFireTime = Time.time + _fireRate;
            }
            
        }

    }
}


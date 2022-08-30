using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour, ITakeDamage
{
    int _activeWeapon;
    List<Weapon> _weapons;
    Health _health;

    private void Awake()
    {
        _weapons = GetComponentsInChildren<Weapon>().ToList();
        _activeWeapon = 0;

    }
    public void TakeDamage()
    {
        SceneManager.LoadScene(0);
    }

    private void Update()
    {
        if (Input.GetButton("Jump"))
        {
            _weapons[_activeWeapon].TryFire();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var iTakeDamage = collision.collider.GetComponent<ITakeDamage>();
        if(iTakeDamage != null)
        {
            iTakeDamage.TakeDamage();
        }
    }

    public void PowerUpWeapon()
    {
        if(_activeWeapon < _weapons.Count-1)
            _activeWeapon++;
    }
}
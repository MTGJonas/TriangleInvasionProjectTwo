using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Mine : MonoBehaviour, ITakeDamage
{
    [SerializeField] private GameObject _effects;
    
    public void TakeDamage()
    {
        Explode();
    }

    private void Explode()
    {
        GetComponentInChildren<SpriteRenderer>().enabled = false;
        _effects.SetActive(true);
        this.enabled = false;
        Destroy(gameObject, 2f);
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    
    int _health;
    [SerializeField] int _maxHealth;
    public bool IsAlive => _health > 0;

    private void Start()
    {
        _health = _maxHealth;
    }

    public void ReduceHealth()
    {
        _health--;
    }
}

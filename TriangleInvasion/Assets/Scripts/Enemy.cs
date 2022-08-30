using System;
using UnityEngine;

public class Enemy : EnemyBase, ITakeDamage
{
    [SerializeField] GameObject _expolsion;
    private Collider2D _collider;
    [SerializeField] SpriteRenderer _spriteRenderer;
    [SerializeField] Health _health;
    private bool isDestroyed;
    
    private void Awake()
    {
        _collider = GetComponent<Collider2D>();
        if (_spriteRenderer == null)
            _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    public void TakeDamage()
    {
        _health.ReduceHealth();
        if(_health.IsAlive == false && !isDestroyed)
            DestoryThis();
    }

    private void DestoryThis()
    {
        BroadcastScore();
        isDestroyed = true;
        Destroy(gameObject, 1);
        _collider.enabled = false;
        _spriteRenderer.enabled = false;
        _expolsion.SetActive(true);
        enabled = false;
    }
}

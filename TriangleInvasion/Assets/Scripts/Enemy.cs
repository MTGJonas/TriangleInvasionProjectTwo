using System;
using UnityEngine;

public class Enemy : BaseMoveForward, ITakeDamage
{
    [SerializeField] GameObject _expolsion;
    private Collider2D _collider;
    [SerializeField] SpriteRenderer _spriteRenderer;
    [SerializeField] Health _health;
    [SerializeField] int _scoreValue = 10;
    private bool isDestroyed;
    public static event Action<int> OnEnemyDeath;

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
        OnEnemyDeath?.Invoke(_scoreValue);
        isDestroyed = true;
        Destroy(gameObject, 1);
        _collider.enabled = false;
        _spriteRenderer.enabled = false;
        _expolsion.SetActive(true);
        enabled = false;
    }
}

using UnityEngine;

public class Enemy : BaseMoveForward, ITakeDamage
{
    [SerializeField] GameObject _expolsion;
    private Collider2D _collider;
    [SerializeField] SpriteRenderer _spriteRenderer;
    [SerializeField] Health _healt;
    private bool isDestroyed;

    private void Awake()
    {
        _collider = GetComponent<Collider2D>();
        if (_spriteRenderer == null)
            _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    public void TakeDamage()
    {
        _healt.ReduceHealth();
        if(_healt.IsAlive == false && !isDestroyed)
            DestoryThis();
    }

    private void DestoryThis()
    {
        isDestroyed = true;
        Destroy(gameObject, 1);
        _collider.enabled = false;
        _spriteRenderer.enabled = false;
        _expolsion.SetActive(true);
        enabled = false;
    }
}

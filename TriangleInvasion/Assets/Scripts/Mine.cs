using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Mine : BaseMoveForward, ITakeDamage
{
    [SerializeField] private GameObject _effects;
    [SerializeField] private float _explosionRange =2f;
    [SerializeField] float _explosionTime = 0.2f;
    bool _beenDestroyed;


    private Collider2D[] _hits = new Collider2D[20];

    public void TakeDamage()
    {
        Explode();
    }

    private void Explode()
    {
        if (_beenDestroyed)
            return;
        _beenDestroyed = true;

        GetComponentInChildren<SpriteRenderer>().enabled = false;
                
        _effects.SetActive(true);
        this.enabled = false;
        Destroy(gameObject, 2f);
        if (Physics2D.OverlapCircleNonAlloc(transform.position, _explosionRange, _hits) > 0)
        {
            foreach (Collider2D hit in _hits)
            {
                if (hit == null) 
                    return;
                var takeDamage = hit.GetComponent<ITakeDamage>();
                if (takeDamage != null && (Object)takeDamage != this)
                    StartCoroutine(ExplosionImpact(takeDamage));
            }
        }
    }

    private IEnumerator ExplosionImpact(ITakeDamage takeDamage)
    {
        yield return new WaitForSeconds(_explosionTime);
        
        if(takeDamage != null)
            takeDamage.TakeDamage();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, _explosionRange);
    }
}

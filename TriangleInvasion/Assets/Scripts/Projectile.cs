using System.Collections.Generic;
using UnityEngine;

public class Projectile :MonoBehaviour 
{
    [SerializeField] float _speed = 4f;
    [SerializeField] float _lifeTime = 2f;
    

    private void Update()
    {
        
        transform.Translate(Vector3.up* Time.deltaTime*_speed);
        

        _lifeTime -= Time.deltaTime;

        if(_lifeTime < 0)
            Destroy(gameObject);
    }
    private void Start()
    {
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var collider = collision.collider.GetComponent<ITakeDamage>();
        if (collider != null)
        {
            collider.TakeDamage();
        }
        Destroy(gameObject);

    }

}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : EnemyBase, ITakeDamage
{
    private enum bossState { first, second, defeated}

    private bossState state = bossState.first;
    private float _xDirection = 1;
    private bool _onTransition;
    [SerializeField] Health _health;
    [SerializeField] List<GameObject> _explosions;
    bool battleStarted = false;
    [SerializeField] Weapon weapon;

    public void TakeDamage()
    {
        if(!battleStarted)
            return;
        _health.ReduceHealth();
    }
    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    
        if (GameManager.Instance.State != GameManager.GameState.Boss)
            return;

        switch (state)
        {
            case bossState.first:
                FirstState();
                break;
            case bossState.second:
                SecondState();
                break;
            case bossState.defeated:
                Defeated();
                break;
            default:
                break;
        }
    }

    private void Defeated()
    {
        _onTransition = true;
        gameObject.SetActive(false);
        GameManager.Instance.BossDefeated();
    }

    private void SecondState()
    {
        if(_onTransition)
        { 
            _onTransition = false;
            transform.localScale = new Vector3(0.2f, 0.2f, 1);
        }
        transform.position += Vector3.right * _xDirection * Time.deltaTime;

        if (!(transform.position.x < 2 && transform.position.x > -2f))
        {
            _xDirection *= -1;
            var clampedX = Mathf.Clamp(transform.position.x, -2, 2);
            transform.position = new Vector3(clampedX, transform.position.y, 0);
        }

        weapon.TryFire();
        if (_health.HealthPct <= 0f)
        {
            StartCoroutine(PlayExplosions());
        }
    }

    private void FirstState()
    {
        battleStarted = true;
        transform.position += Vector3.right * _xDirection * Time.deltaTime;
        if (!(transform.position.x < 2 && transform.position.x > -2f))
        {
            _xDirection *= -1;
            var clampedX = Mathf.Clamp(transform.position.x, -2, 2);
            transform.position = new Vector3(clampedX, transform.position.y, 0);
        }

        if (_health.HealthPct < 0.5f)
        {
            state = bossState.second;
            _onTransition = true;
        }


    }

    private IEnumerator PlayExplosions()
    {
        foreach (GameObject explosion in _explosions)
        {
            explosion.SetActive(true);
            yield return new WaitForSeconds(0.2f);
        }
        EndBattle();    
    }

    private void EndBattle()
    {
        state = bossState.defeated;
        _onTransition = true;
    }


}

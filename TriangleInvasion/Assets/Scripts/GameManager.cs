using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singelton
    public static GameManager Instance;

   
    private void Awake()

    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogError($"Game Manager is getting Instanciated more then once by {gameObject.name}");
        }
    }
    #endregion

    

    private GameState _state;
    private float _baseSpeed = 0;

    public event Action StateChanged;
    public GameState State => _state;
    public float BaseSpeed => _baseSpeed;

    public enum GameState { Running, Boss, Stopped }
    private void Start()
    {
        SetState(GameState.Stopped);
        StartCoroutine(StartAfterDelay(2f));
    }

    private IEnumerator StartAfterDelay(float v)
    {
        yield return new WaitForSeconds(v);
        Instance.SetState(GameState.Running);
    }

    private void TrySetState(GameState newState)
    {
        if(_state == GameState.Running)
        {
            if (newState == GameState.Stopped ||
                newState == GameState.Boss)
                SetState(newState);
            
        }
        else if(_state == GameState.Boss)
        {
            if(newState == GameState.Running)
                SetState(newState);
        }
        else if(_state == GameState.Stopped)
        {
            if(newState == GameState.Running)
                SetState(_state);
        }
    }

    private void SetState(GameState newState)
    {
        if (newState == GameState.Running)
            SetRunningState();
        else if (newState == GameState.Boss)
            SetBossState();
        else if (newState == GameState.Stopped)
            SetFinnishedState();
    }

    private void SetFinnishedState()
    {
        _baseSpeed = 0f;
        _state = GameState.Stopped;
        StateChanged?.Invoke();
    }

    private void SetBossState()
    {
        _baseSpeed = 0f;
        _state = GameState.Boss;
        StateChanged?.Invoke();
    }

    private void SetRunningState()
    {
        _baseSpeed = 1f;
        _state = GameState.Running;
        StateChanged?.Invoke();
    }

    internal void BossDefeated()
    {
        TrySetState(GameState.Running);
    }

    internal void BossReached()
    {
        TrySetState(GameState.Boss);
    }
}


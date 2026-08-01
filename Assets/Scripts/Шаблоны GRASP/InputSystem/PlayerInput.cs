using System;
using UnityEngine;


public sealed class PlayerInput : MonoBehaviour, ISceneCycle, ISceneCycleUpdate
{

    private Vector2 _vectorPlayer;
    public Action _playerAttack;
    public Vector2 VectorPlayer
    {
        get
        {
            return _vectorPlayer;
        }
    }

    public void CycleUpdate()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            _playerAttack?.Invoke();
        }

        float _abscissa = Input.GetAxis("Horizontal");

        _vectorPlayer.x = _abscissa;
        _vectorPlayer.y = 0;
    }
}

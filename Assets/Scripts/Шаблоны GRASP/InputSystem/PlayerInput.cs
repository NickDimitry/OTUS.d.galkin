using System;
using UnityEngine;


// Не забыть уточнить, можно ли было использовать новую систему ввода Unity


public sealed class PlayerInput: MonoBehaviour
{
    #region Поля

    private Vector2 _vectorPlayer;

    #endregion

    #region Event

    public Action _playerAttack;

    #endregion

    #region Свойства
    public Vector2 VectorPlayer
    {
        get
        {
            return _vectorPlayer;
        }
    }
    #endregion

    #region MonoBehaviour
    private void Update() // Вот, что-то мне тут не нравится, но не могу сказать что..... На подумать.
    {
        if (Input.GetButtonDown("Fire1"))
        {
            _playerAttack?.Invoke();
        }

        float _abscissa = Input.GetAxis("Horizontal");

        _vectorPlayer.x = _abscissa;
        _vectorPlayer.y = 0;
    }
    #endregion
}

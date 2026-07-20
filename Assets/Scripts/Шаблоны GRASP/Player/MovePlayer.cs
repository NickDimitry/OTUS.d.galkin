using System;
using System.Numerics;
using UnityEngine;

// Уточнить можно ли получать изначальные данные для _speed из  Scriptable

[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(Rigidbody2D))]
public sealed class MovePlayer : MonoBehaviour
{
    #region Поля

    [SerializeField] private float _speed = 5f;

    #endregion

    #region Ссылки

    private PlayerInput _input;
    private Rigidbody2D _rigidbody2D;

    #endregion

    #region MonoBehaviour

    private void Start()
    {
        _input = GetComponent<PlayerInput>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        var nextPosition = _rigidbody2D.position + _input.VectorPlayer * (_speed * Time.deltaTime);
        _rigidbody2D.MovePosition(nextPosition);
    }

    #endregion
}

using System;
using UnityEngine;

// Уточнить можно ли получать изначальные данные для _speed из  Scriptable

[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(CharacterController))]
public sealed class MovePlayer : MonoBehaviour
{
    #region Поля

    [SerializeField] private float _speed = 5f;

    #endregion

    #region Ссылки

    private PlayerInput _input;
    private CharacterController _characterController;

    #endregion

    #region MonoBehaviour

    private void Start()
    {
        _input = GetComponent<PlayerInput>();
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        _characterController.Move(_input.VectorPlayer * (_speed * Time.deltaTime));
    }

    #endregion
}

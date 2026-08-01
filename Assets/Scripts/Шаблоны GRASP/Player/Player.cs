using UnityEngine;

public sealed class Player : MonoBehaviour, ISceneCycle, ISceneCycleAwake
{
    private SceneCycleController _sceneCycleController;

    private MovePlayer _movePlayer;
    private PlayerInput _playerInput;
    private PlayerAttack _playerAttack;
    private PlayerLive _playerLive;

    public void CycleAwake()
    {
        _sceneCycleController = FindAnyObjectByType<SceneCycleController>();

        gameObject.AddComponent<MovePlayer>();
        gameObject.AddComponent<PlayerInput>();
        gameObject.AddComponent<PlayerAttack>();
        gameObject.AddComponent<PlayerLive>();

        _movePlayer = GetComponent<MovePlayer>();
        _playerInput = GetComponent<PlayerInput>();
        _playerAttack = GetComponent<PlayerAttack>();
        _playerLive = GetComponent<PlayerLive>();

        _sceneCycleController.RegisterSceneCycleService(_movePlayer);
        _sceneCycleController.RegisterSceneCycleService(_playerInput);
        _sceneCycleController.RegisterSceneCycleService(_playerAttack);
        _sceneCycleController.RegisterSceneCycleService(_playerLive);
    }

}

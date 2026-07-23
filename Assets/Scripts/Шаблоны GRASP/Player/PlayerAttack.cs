using ShootEmUp;
using UnityEngine;


[RequireComponent(typeof(PlayerInput))]
public sealed class PlayerAttack : MonoBehaviour
{

    #region —сылки

    private BulletSystem _bulletSystem;
    private Transform _firePoint;
    private BulletConfig _playerBulletConfig;
    private const string PATH_PLAYER_BULLET = "Bullet/PlayerBullet";

    #endregion
    #region MonoBehaviour

    private void OnEnable()
    {
        GetComponent<PlayerInput>()._playerAttack += Fire;
    }

    private void Start()
    {
        _bulletSystem = FindFirstObjectByType<BulletSystem>();
        _firePoint = GameObject.Find("FirePoint").GetComponent<Transform>();    
        _playerBulletConfig = Resources.Load<BulletConfig>(PATH_PLAYER_BULLET);
    }

    private void OnDisable()
    {
        GetComponent<PlayerInput>()._playerAttack -= Fire;
    }
    #endregion

    private void Fire()
    {
        _bulletSystem.FlyBulletByArgs(new BulletSystem.Args
        {
            isPlayer = true,
            physicsLayer = (int)_playerBulletConfig.physicsLayer,
            color = _playerBulletConfig.color,
            damage = _playerBulletConfig.damage,
            position = _firePoint.position,
            velocity = _firePoint.rotation * Vector3.up * _playerBulletConfig.speed
        });

    }
}

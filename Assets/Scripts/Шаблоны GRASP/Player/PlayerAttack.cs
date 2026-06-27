using ShootEmUp;
using UnityEngine;

// Вот что-то мне тут не нравится.... Подумать как можно плучать данные из конфига другим способом, для начала.

[RequireComponent(typeof(PlayerInput))]
public sealed class PlayerAttack : MonoBehaviour
{

    #region Ссылки

    private BulletSystem _bulletSystem;
    private Transform _firePoint;
    private BulletConfig _playerBulletConfig;

    #endregion
    #region MonoBehaviour

    private void Start()
    {
        _bulletSystem = FindFirstObjectByType<BulletSystem>();
        _firePoint = GameObject.Find("FirePoint").GetComponent<Transform>();    
        _playerBulletConfig = Resources.Load<BulletConfig>("Bullet/PlayerBullet");
        GetComponent<PlayerInput>()._playerAttack += Fire;
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

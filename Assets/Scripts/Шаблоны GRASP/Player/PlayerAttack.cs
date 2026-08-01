using ShootEmUp;
using UnityEngine;


[RequireComponent(typeof(PlayerInput))]
public sealed class PlayerAttack : MonoBehaviour, ISceneCycle, ISceneCycleStart, ISceneCycleOnDisable
{

    private BulletSystem _bulletSystem;
    private Transform _firePoint;
    private BulletConfig _playerBulletConfig;
    private const string PATH_PLAYER_BULLET = "Bullet/PlayerBullet";

    private void OnEnable()
    {
        GetComponent<PlayerInput>()._playerAttack += Fire;
    }

    public void CycleStart()
    {
        _bulletSystem = FindFirstObjectByType<BulletSystem>();
        _firePoint = GameObject.Find("FirePoint").GetComponent<Transform>();
        _playerBulletConfig = Resources.Load<BulletConfig>(PATH_PLAYER_BULLET);
    }


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

    public void CycleOnDisable()
    {
        GetComponent<PlayerInput>()._playerAttack -= Fire;
    }
}

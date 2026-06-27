using ShootEmUp;
using UnityEngine;

public sealed class CurrentBullet : MonoBehaviour
{
    [SerializeField] private BulletConfig _currentBullet;

    public BulletConfig Bullet
    {
        get
        { 
            return _currentBullet;  
        }
    }
}

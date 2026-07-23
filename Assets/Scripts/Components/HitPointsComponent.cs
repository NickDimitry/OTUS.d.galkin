using System;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class HitPointsComponent : MonoBehaviour, IEnemyHealth
    {
         public event Action<GameObject> hpEmpty;
        
        [SerializeField] private int _hitPoints;
        
        public void TakeDamage(int damage)
        {
            _hitPoints -= damage;
            if (_hitPoints <= 0)
            {
                hpEmpty?.Invoke(gameObject);
            }
        }
    }
}
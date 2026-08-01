using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyMoveAgent : MonoBehaviour, ISceneCycle, ISceneCycleFixedUpdate
    {
        [SerializeField] private MoveComponent _moveComponent;

        private Vector2 _destination;
        private bool _isReached;
        private const float DISTANCE = 0.25f;
        public bool IsReached
        {
            get { return _isReached; }
        }


        public void CycleFixedUpdate()
        {
            if (_isReached)
            {
                return;
            }

            var vector = _destination - (Vector2)transform.position;
            if (vector.magnitude <= DISTANCE)
            {
                _isReached = true;
                return;
            }

            var direction = vector.normalized * Time.fixedDeltaTime;
            _moveComponent.MoveByRigidbodyVelocity(direction);
        }


        public void SetDestination(Vector2 endPoint)
        {
            _destination = endPoint;
            _isReached = false;
        }

    
    }
}
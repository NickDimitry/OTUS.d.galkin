using System;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class LevelBackground : MonoBehaviour, ISceneCycle, ISceneCycleAwake, ISceneCycleFixedUpdate
    {
        private float _startPositionY;

        private float _endPositionY;

        private float _movingSpeedY;

        private float _positionX;

        private float _positionZ;

        private Transform _myTransform;

        [SerializeField]
        private Params _params;

        public void CycleAwake()
        {
            _startPositionY = _params.m_startPositionY;
            _endPositionY = _params.m_endPositionY;
            _movingSpeedY = _params.m_movingSpeedY;
            _myTransform = transform;
            var position = _myTransform.position;
            _positionX = position.x;
            _positionZ = position.z;
        }

        public void CycleFixedUpdate()
        {
            if (_myTransform.position.y <= _endPositionY)
            {
                _myTransform.position = new Vector3(
                    _positionX,
                    _startPositionY,
                    _positionZ
                );
            }

            _myTransform.position -= new Vector3(
                _positionX,
                _movingSpeedY * Time.fixedDeltaTime,
                _positionZ
            );
        }


        [Serializable]
        public sealed class Params
        {
            [SerializeField]
            public float m_startPositionY;

            [SerializeField]
            public float m_endPositionY;

            [SerializeField]
            public float m_movingSpeedY;
        }
    }
}
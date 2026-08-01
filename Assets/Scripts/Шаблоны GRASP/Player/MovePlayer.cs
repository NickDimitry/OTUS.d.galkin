using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public sealed class MovePlayer : MonoBehaviour, ISceneCycle, ISceneCycleStart, ISceneCycleUpdate
{

    [SerializeField] private float _speed = 5f;

    private PlayerInput _input;
    private Rigidbody2D _rigidbody2D;

    public void CycleStart()
    {
        _input = GetComponent<PlayerInput>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void CycleUpdate()
    {
        var nextPosition = _rigidbody2D.position + _input.VectorPlayer * (_speed * Time.deltaTime);
        _rigidbody2D.MovePosition(nextPosition);
    }

}

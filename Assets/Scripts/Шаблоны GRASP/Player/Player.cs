using UnityEngine;

public sealed class Player : MonoBehaviour
{
    private void Awake()
    {
        gameObject.AddComponent<MovePlayer>();
        gameObject.AddComponent<PlayerAttack>();
        gameObject.AddComponent<PlayerLive>();
    }
}

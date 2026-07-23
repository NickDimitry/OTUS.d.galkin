using ShootEmUp;
using UnityEngine;

public class PlayerLive : MonoBehaviour
{
    private HitPointsComponent _hitPointsComponent;


    private void Start()
    {
        _hitPointsComponent = GetComponent<HitPointsComponent>();
        _hitPointsComponent.hpEmpty += DestroyPlayer;
    }

    private void DestroyPlayer(GameObject player)
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        _hitPointsComponent.hpEmpty -= DestroyPlayer;
        _hitPointsComponent.HitPoints = 5;
    }

    private void OnDestroy()
    {
        _hitPointsComponent.hpEmpty -= DestroyPlayer;
    }
}

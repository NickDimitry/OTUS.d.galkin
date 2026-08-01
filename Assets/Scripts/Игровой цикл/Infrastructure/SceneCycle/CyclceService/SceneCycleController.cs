using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(-5000)]
public sealed class SceneCycleController : MonoBehaviour
{
    [SerializeField] private List<MonoBehaviour> _entities = new();
    private SceneCycleService _sceneCycleService = new();

    public void RegisterSceneCycleService(ISceneCycle SceneCycle)
    {
        _sceneCycleService.Register(SceneCycle);
    }

    private void Awake()
    {
        foreach (var entity in _entities)
        {
            if (entity is ISceneCycle SceneCycle)
            {
                _sceneCycleService.Register(SceneCycle);
            }
        }
    }

    private void Start()
    {
        _sceneCycleService.SceneAwake();
        _sceneCycleService.SceneStart();
    }

    private void Update()
    {
       _sceneCycleService.SceneUpdate();
    }

}

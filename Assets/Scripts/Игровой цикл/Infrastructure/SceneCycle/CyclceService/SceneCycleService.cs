using System.Collections.Generic;

// В рамках практики, оставляю коментарии для закрипления материала
public sealed class SceneCycleService: ISceneCycleService
{
    private readonly List<ISceneCycleAwake> _cycleAwake = new();
    private readonly List<ISceneCycleStart> _cycleStart = new();
    private readonly List<ISceneCycleUpdate> _cycleUpdate = new();
    private readonly List<ISceneCyclePause> _cyclePause = new();
    private readonly List<ISceneCycleOnDisable> _cycleOnDisable = new();

    private bool _isPause = false;
    public void SceneAwake()
    {
        foreach (var cycle in _cycleAwake)
        {
            cycle.CycleAwake();
        }
    }

    public void SceneStart()
    {
        foreach (var cycle in _cycleStart)
        {
            cycle.CycleStart();
        }
    }

    public void ScenePause()
    {
        _isPause = !_isPause;
    }
    public void SceneUpdate()
    {
        if (!_isPause)
        {
            foreach (var cycle in _cycleUpdate)
            {
                cycle.CycleUpdate();
            }
        }
    }

    public void SceneeOnDisable()
    {
        foreach (var cycle in _cycleOnDisable)
        {
            cycle.CycleOnDisable();
        }
    }

    public void Register(ISceneCycle SceneCycle) // Применяем => Type Pattern (Шаблон типа) из технологии Pattern Matching
    {
        if (SceneCycle is ISceneCycleAwake CycleAwake && !_cycleAwake.Contains(CycleAwake)) 
        {
            _cycleAwake.Add(CycleAwake);
        }

        if (SceneCycle is ISceneCycleStart CycleStart && !_cycleStart.Contains(CycleStart)) 
        {
            _cycleStart.Add(CycleStart);
        }

        if (SceneCycle is ISceneCycleUpdate CycleUpdate && !_cycleUpdate.Contains(CycleUpdate))
        {
            _cycleUpdate.Add(CycleUpdate);
        }

        if (SceneCycle is ISceneCyclePause CyclePause && !_cyclePause.Contains(CyclePause))
        {
            _cyclePause.Add(CyclePause);
        }

        if (SceneCycle is ISceneCycleOnDisable CycleOnDisable && !_cycleOnDisable.Contains(CycleOnDisable)) 
        {
            _cycleOnDisable.Add(CycleOnDisable);
        }

    }

    
}

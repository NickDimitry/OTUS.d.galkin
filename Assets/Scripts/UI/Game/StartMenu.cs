using DG.Tweening;
using ShootEmUp;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public sealed class StartMenu : MonoBehaviour, ISceneCycle, ISceneCycleAwake
{
    [Header("DI")]
    [SerializeField] private SceneCycleController _sceneCycleController;
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private BulletSystem _bulletSystem;

    [Header("Button")]
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _pauseButton;

    [Header("Panel")]
    [SerializeField] private Image _backgraund;

    [Header("Text")]
    [SerializeField] private TextMeshProUGUI _startCounter;

    [Header("UI Setting")]
    [SerializeField] private int _startSeconds;

    private bool _isPuase = false;

    public void CycleAwake()
    {
        _sceneCycleController = FindAnyObjectByType<SceneCycleController>();
        _sceneCycleController.Pause();

        _startButton.onClick.AddListener(CounterStartGame);
        _pauseButton.onClick.AddListener(Pause);
    }

    private void CounterStartGame()
    {
        int countdown = _startSeconds;

        _startButton.gameObject.SetActive(false);
        _startCounter.gameObject.SetActive(true);

        DOTween.To
            (() => countdown, x => countdown = x, 0, _startSeconds)
            .SetEase(Ease.Linear)
            .OnUpdate(() => {_startCounter.text = countdown.ToString();}
            )
            .OnComplete(StartGame);

    }

    private void Pause()
    {
        _isPuase = !_isPuase;

        if (_isPuase)
        {
            _sceneCycleController.Pause();
            _bulletSystem.StopActiveBullet();
        }

        if (!_isPuase)
        {
            _sceneCycleController.Pause();
            _bulletSystem.RunActiveBullet();
        }

    }

    private void StartGame()
    {
        _startCounter.gameObject.SetActive(false);
        _sceneCycleController.Pause();
        _backgraund.gameObject.SetActive(false);
        _pauseButton.gameObject.SetActive(true);
    }
}

using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class SwitchPlayers : MonoBehaviour
{
    [Min(0)]
    [SerializeField] private float _delaySwitch;
    [Min(5f)]
    [SerializeField] private int _timeRound;
    [Header("Reference")]
    [SerializeField] private SwitchEntity[] _parts;
    [Header("Event")]
    [SerializeField] private UnityEvent<int> _onUpdateTimer; 

    private float _progress = 0f;
    private SwitchEntity _currentPlayer;

    private List<SwitchEntity> _accesPlayer = new List<SwitchEntity>();

    private void OnValidate()
    {
        _onUpdateTimer.Invoke(_timeRound);
    }

    private void Reset()
    {
        _timeRound = 5;
        _parts = GetComponentsInChildren<SwitchEntity>();
    }

    private void Awake()
    { 
        Restart();
    }

    private void Update()
    {
        _progress = Mathf.Clamp01(_progress + Time.deltaTime / _timeRound);
        _onUpdateTimer.Invoke(_timeRound - (int)(_progress * _timeRound));
        if (_progress >= 1f)
        {
            _currentPlayer.Exit();
        }
    }

    public void Restart()
    {
        _onUpdateTimer.Invoke(_timeRound);
        foreach (var part in _parts)
        {
            part.OnComplite -= SwitchGame;
            part.Exit();
        }
        _accesPlayer.Clear();
        _accesPlayer.AddRange(_parts);
        SwitchGame();
    }

    public void SwitchGame(SwitchEntity entity = null)
    {
        _progress = 0f;
        if (entity)
        {
            _accesPlayer.Remove(entity);
            entity.OnComplite -= SwitchGame;
        } 
        _currentPlayer = GetNextEntity();
        _currentPlayer.OnComplite += SwitchGame; 
        _currentPlayer.Enter();
    }

    private SwitchEntity GetNextEntity()
    {
        if (_accesPlayer.Count == 0)
        {
            _accesPlayer.AddRange(_parts);
        }
        return _accesPlayer[0];
    }

}

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
    private SwitchEntity _curretEntity;

    private List<SwitchEntity> _accesEntity = new List<SwitchEntity>();

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
        _onUpdateTimer.Invoke(0);
        foreach (var part in _parts)
        {
            part.Exit();
        }
        SwitchGame();
    }

    private void Update()
    {
        _progress = Mathf.Clamp01(_progress + Time.deltaTime / _timeRound);
        _onUpdateTimer.Invoke(30 - (int)(_progress * _timeRound));
        if (_progress >= 1f)
        {
            _curretEntity.Exit();
        }
    }

    public void SwitchGame(SwitchEntity entity = null)
    {
        _progress = 0f;
        if (entity)
        {
            _accesEntity.Remove(entity);
            entity.OnComplite -= SwitchGame;
        }
        _curretEntity = GetNextEntity();
        _curretEntity.OnComplite += SwitchGame;
        _curretEntity.Enter();
    }

    private SwitchEntity GetNextEntity()
    {
        if (_accesEntity.Count == 0)
        {
            _accesEntity.AddRange(_parts);
        }
        return _accesEntity[0];
    }

}

using System.Collections;
using UnityEngine;

[RequireComponent(typeof(ShotDirection), typeof(Algoritm))]
public class Shot : SwitchEntity
{
    [SerializeField] private BombHolder _bombPrefab;

    private Algoritm mathf;
    private ShotDirection track;

    private bool _isShooting;
    private Coroutine _corotine;

    private void Awake()
    {
        track = GetComponentInParent<ShotDirection>();
        mathf = GetComponentInParent<Algoritm>();
    }

    public override void Enter()
    {
        if (_corotine == null)
            _corotine = StartCoroutine(ShotCoroutine());
    }

    public override void Exit()
    {
        if (!_isShooting)
        {
            CompliteSteap();
            if (_corotine != null)
            {
                StopCoroutine(_corotine);
                _corotine = null;
            }
        }
    }

    private IEnumerator ShotCoroutine()
    {
        yield return new WaitForSeconds(3);
        ShotOnTarget();
        _corotine = null;
    }

    private void ShotOnTarget()
    {
        var bomb = _bombPrefab.Create(track.pointer.position, track.pointer.rotation);
        bomb.SetVelocity(track.pointer.up * mathf.speedV);
        bomb.OnHit += CompliteShoot;
        _isShooting = true;
    }

    private void CompliteShoot(Bomb bomb)
    {
        bomb.OnHit -= CompliteShoot;
        _isShooting = false;
        Exit();
    }
}
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(ShotDirection), typeof(Algoritm))]
public class Shot : SwitchEntity
{
    private AudioManager audioManager;
    [SerializeField] private int _mask;
    [SerializeField] private BombHolder _bombPrefab;

    [SerializeField] public GameObject gun;
    [SerializeField] public GameObject arrow;

    private Algoritm mathf;
    private ShotDirection track;

    private bool _isShooting;
    private Coroutine _corotine;

    private void Awake()
    {
        audioManager = AudioManager.instanceAudio;
        track = GetComponentInParent<ShotDirection>();
        mathf = GetComponentInParent<Algoritm>();
    }

    public override void Enter()
    {
        if (_corotine == null)
        {
            gun.gameObject.SetActive(true);
            arrow.gameObject.SetActive(true);
            _corotine = StartCoroutine(ShotCoroutine());
        }
            
    }

    public override void Exit()
    {
        if (!_isShooting)
        {
            gun.gameObject.SetActive(false);
            arrow.gameObject.SetActive(false);
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
        bomb.gameObject.layer = _mask;
        bomb.SetVelocity(track.pointer.up * mathf.speedV);
        bomb.OnHit += CompliteShoot;
        _isShooting = true;
        audioManager.PlayFireSound();
    }

    private void CompliteShoot(Bomb bomb)
    {
        bomb.OnHit -= CompliteShoot;
        _isShooting = false;
        Exit();
    }
}
using System.Collections;
using System.Reflection;
using UnityEngine;

public class PlayerCntroller : SwitchEntity
{
    [SerializeField] private Worm _worm;
    [SerializeField] private Throwing _trowing;
    [SerializeField] private Transform _wormSprite;
    public GameObject arrow;
    public GameObject gun;
    private Coroutine _coroutine;

    private float horizontal { get; set; }
    private void Update()
    {
        _worm.Jump(Input.GetKeyDown(KeyCode.Space));
        _trowing.PointerLine();
        if (Input.GetMouseButtonUp(0))
        {   
            _trowing.Shot(true).OnHit += WaitHit;
            enabled = false;
        }
    }

    private void FixedUpdate()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        _worm.Move(horizontal);
    }  
    public override void Enter()
    {
        gun.gameObject.SetActive(true);
        arrow.gameObject.SetActive(true);
        StartCoroutine(DeactivArrowCoroutine());
        enabled = true;
        _worm.ResetDistance();
    }

    public override void Exit()
    {
        gun.gameObject.SetActive(false);
        arrow.gameObject.SetActive(false);
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }
        enabled = false;
        CompliteSteap();
    }

    private void WaitHit(Bomb bomb)
    {
        bomb.OnHit -= WaitHit;
        Exit();
    }
    private IEnumerator DeactivArrowCoroutine()
    {
        yield return new WaitForSeconds(4);
        arrow.gameObject.SetActive(false);
    }

}

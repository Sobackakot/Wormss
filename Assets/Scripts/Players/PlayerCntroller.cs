using UnityEngine;

public class PlayerCntroller : SwitchEntity
{
    [SerializeField] private Worm _worm;
    [SerializeField] private Throwing _trowing;

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
        float horizontal = Input.GetAxisRaw("Horizontal");
        _worm.Move(horizontal);
    }

    public override void Enter()
    {
        enabled = true;
        _worm.ResetPlayer();
    }

    public override void Exit()
    {
        enabled = false;
        CompliteSteap();
    }

    private void WaitHit(Bomb bomb)
    {
        bomb.OnHit -= WaitHit;
        Exit();
    }

}

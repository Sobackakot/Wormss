using System.Collections;
using UnityEngine.Events;
using UnityEngine;

public class Worm : MonoBehaviour, IDamage
{
    [Min(1)]
    [SerializeField] private int _health;
    [Min(0)]
    [SerializeField] private float _speed;
    [Min(0)]
    [SerializeField] private float _jumpSpeed;
    [Min(1)]
    [SerializeField] private float _moveDistance;
    [Header("Reference")]
    [SerializeField] private Animator _animator;
    [SerializeField] private Transform _wormSprite;
    [SerializeField] private Rigidbody2D _rigidbody;
    [Header("Events")]
    [SerializeField] private UnityEvent<float> _onUpdateHealth;
    [SerializeField] private UnityEvent<float> _onUpdateMoveProgress;

    private bool _isDead;
    private bool _isGround;
    private float _curretHealth;
    private float _curretDistance;

    public event System.Action OnDead;

    private void Reset()
    {
        _health = 100;
        _speed = 2f;
        _jumpSpeed = 5f;
        _moveDistance = 10f;
    }

    private void OnValidate()
    {
        ResetPlayer();
    }

    private void Awake()
    {
        ResetPlayer();
    }

    public void Move(float horizontal)
    {
        if (horizontal != 0)
            _wormSprite.localScale = new Vector3(-horizontal, 1f, 1f);
        if (horizontal != 0 && _curretDistance < _moveDistance)
        {
            Vector2 velocity = _rigidbody.velocity;
            velocity.x = horizontal * _speed;
            _rigidbody.velocity = velocity;
            _curretDistance += Mathf.Abs(velocity.x * Time.fixedDeltaTime);
            _onUpdateMoveProgress.Invoke(1 - _curretDistance / _moveDistance);
            _animator.SetBool("Walk", true);
        }
        else
        {
            _animator.SetBool("Walk", false);
        }
    }

    public void Jump(bool jump)
    {
        if (jump && _isGround)
        {
            _rigidbody.velocity += new Vector2(0, _jumpSpeed);
            _animator.SetBool("Grounded", false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _isGround = true;
        _animator.SetBool("Grounded", true);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        _isGround = false;
        _animator.SetBool("Grounded", false);
    }

    public void ResetPlayer()
    {
        _isDead = false;
        _curretHealth = _health;
        _onUpdateHealth.Invoke(_curretHealth / _health);
        ResetDistance();
    }

    public void ResetDistance()
    {
        _curretDistance = 0f;
        _onUpdateMoveProgress.Invoke(1 - _curretDistance / _moveDistance);
    }

    public void TakeDamage(int damage)
    {
        _curretHealth = Mathf.Clamp(_curretHealth - damage, 0, _curretHealth);
        _onUpdateHealth.Invoke(_curretHealth / _health);
        if (_curretHealth == 0 && !_isDead)
        {
            _isDead = true;
            StartCoroutine(Dead(1));
        }
    }

    private IEnumerator Dead(float delay)
    {
        yield return new WaitForSeconds(delay);
        OnDead?.Invoke();
    }
}

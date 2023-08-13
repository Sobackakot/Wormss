using UnityEngine;

public class Bomb : MonoBehaviour
{
    [Min(1)]
    [SerializeField] private int _damage;
    [Min(1)]
    [SerializeField] private float _timeDestroy;
    [Header("Reference")]
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private GameObject _explosionPrefab;

    private Cutter _cut;
    private bool _dead;

    public event System.Action<Bomb> OnHit;

    private void Reset()
    {
        _damage = 10;
        _timeDestroy = 5f;
    }

    private void Start()
    {
        _cut = FindObjectOfType<Cutter>();
        Invoke("Explosion", _timeDestroy);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out Worm worm))
        {
            worm.TakeDamage(_damage);
            Explosion();
        }
        else if (!_dead)
        {
            _cut.transform.position = transform.position;
            Invoke(nameof(DoCut), 0.001f);
            _dead = true;
        }
    }
    public void SetVelocity(Vector2 value)
    {
        _rigidbody.velocity = value;
        _rigidbody.AddTorque(Random.Range(-8f, 8f));
    }

    private void DoCut() 
    {
        _cut.DoCut();
        Explosion();
    }

    private void Explosion()
    {
        Destroy(gameObject);
        Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
        OnHit?.Invoke(this);
    }

}

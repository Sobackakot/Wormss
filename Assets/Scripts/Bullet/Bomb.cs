using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] private int _damage;
    [Header("Reference")]
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private GameObject _explosionPrefab;

    private Cutter _cut;
    private bool _dead;

    public void SetVelocity(Vector2 value) {
        _rigidbody.velocity = value;
        _rigidbody.AddTorque(Random.Range(-8f,8f));
    }

    private void Start()
    {
        _cut = FindObjectOfType<Cutter>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out Worm worm))
        {
            worm.TakeDamage(_damage);
            Destroy(gameObject);
            Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
        }
        else if (!_dead)
        {
            _cut.transform.position = transform.position;
            Invoke(nameof(DoCut), 0.001f);
            _dead = true;
        }
    }

    void DoCut() 
    {
        _cut.DoCut();
        Destroy(gameObject);
        Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
    }

}

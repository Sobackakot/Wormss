using UnityEngine;

public class Throwing : MonoBehaviour
{
    [HideInInspector] public bool isActiveGame = false;

    [SerializeField] private Renderer _renderer;
    [SerializeField] private float _sencetivity = 0.01f;
    [SerializeField] private float _speedMultiplier = 0.03f;
    [SerializeField] private Bomb _bombPrefab;
    [SerializeField] private Transform _pointerLine;

    Vector3 mouseStart;

    private void Start()
    {
        _renderer.enabled = false;
    }

    public void PointerLine()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _renderer.enabled = true;
            mouseStart = Input.mousePosition;
        }
        if (Input.GetMouseButton(0))
        {
            Vector3 delta = Input.mousePosition - mouseStart;
            transform.right = delta;
            _pointerLine.localScale = new Vector3(delta.magnitude * _sencetivity, 1, 1);
        }
    }

    public Bomb Shot(bool shoot)
    {
        if (shoot)
        {
            Vector3 delta = Input.mousePosition - mouseStart;
            Vector3 velocity = delta * _speedMultiplier;
            _renderer.enabled = false;
            Bomb newBomb = Instantiate(_bombPrefab, transform.position, Quaternion.identity);
            newBomb.SetVelocity(velocity);
            return newBomb;
        }
        return null;
    }
}

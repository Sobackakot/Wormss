using UnityEngine;

public class BombHolder : MonoBehaviour
{
    [SerializeField] private Bomb _prefab;

    private Bomb _bomb;

    public Bomb Create(Vector2 position, Quaternion rotation)
    {
        _bomb = Instantiate(_prefab.gameObject, position, rotation).
            GetComponent<Bomb>();
        return _bomb;
    }

    public void Clear()
    {
        if(_bomb)
            Destroy(_bomb.gameObject);
    }
}

using UnityEngine;

public class GunShoot : MonoBehaviour
{
    [SerializeField] private Vector2 _force;
    [SerializeField] private Bullet _bullet;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Debug.Log("shoot");
            var bullet = Instantiate(_bullet.gameObject, transform.position, Quaternion.identity).
                GetComponent<Bullet>();
            bullet.SetForce(_force.y, _force.x);
        }
    }
}

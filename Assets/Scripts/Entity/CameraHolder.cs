using UnityEngine;

public class CameraHolder : MonoBehaviour
{
    [Min(1)]
    [SerializeField] private float _moveSpeed;
    [Min(1)]
    [SerializeField] private float _zoomSpeed;
    [SerializeField] private Vector2 _zoom;
    [Range(0,1f)]
    [SerializeField] private float _smoothTime = 0.2f;
    [Header("Reference")]
    [SerializeField] private Camera _camera;

    private Vector2 _velocity;
    private Vector3 _target;

    private void Reset()
    {
        _zoomSpeed = 1f;
        _moveSpeed = 1f;
    }

    private void OnValidate()
    {
        if(_zoom.x > _zoom.y)
            _zoom.x = _zoom.y;
    }

    private void Awake()
    {
        _target = transform.position;
    }

    private void Update()
    {
        Move();
        Zoom();
        MoveToPosition();
    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            var move = new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
            _target += move * _moveSpeed * Time.deltaTime;
        }
    }

    private void Zoom()
    {
        var scroll = Input.GetAxis("Mouse ScrollWheel");
        _camera.orthographicSize = Mathf.Clamp(_camera.orthographicSize -
            scroll * _zoomSpeed, _zoom.x, _zoom.y);
    }

    private void MoveToPosition()
    {
        transform.position = Vector2.SmoothDamp(transform.position, _target,
            ref _velocity, _smoothTime);
    }
}

using UnityEngine;

public class CameraHolder : MonoBehaviour
{
    [Range(0,1f)]
    [SerializeField] private float _smoothTime = 0.2f;
    [Header("Reference")]
    [SerializeField] private Transform _target;

    private Vector2 _velocity;

    private void LateUpdate()
    {
        transform.position = Vector2.SmoothDamp(transform.position, _target.position,
            ref _velocity, _smoothTime); ;
    }
}

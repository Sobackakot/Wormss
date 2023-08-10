using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _height;
    [SerializeField] private float _distance;
    [SerializeField] private float _timeDelte;
    [SerializeField] private AnimationCurve _curve;

    private Vector2 _startPosition;
    private float _pogress = 0f;

    private void Update()
    {
        _pogress += Time.deltaTime / (_timeDelte * _height);
        transform.position = _startPosition + Vector2.up * _height * _curve.Evaluate(_pogress) + 
            Vector2.right * _distance * _pogress;
        if (_pogress >= 1)
        {
            Destroy(gameObject);
        }
    }

    public void SetForce(float height, float distance)
    {
        _height = height;
        _distance = distance;
        enabled = true;
        _startPosition = transform.position;
    }
}

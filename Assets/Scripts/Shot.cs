using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    [SerializeField] Rigidbody2D _bombPrefab;

    private Algoritm mathf;
    private ShotDirection track;
    private void Awake()
    {
        track = GetComponentInParent<ShotDirection>();
        mathf = GetComponentInParent<Algoritm>();
    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Rigidbody2D newBomb = Instantiate(_bombPrefab, track.pointer.position, track.pointer.rotation) as Rigidbody2D;
            Vector2 velocity = track.pointer.up * mathf.speedV;
            newBomb.velocity = velocity;
            newBomb.AddTorque(Random.Range(-8f, 8f));
        }
    }
}
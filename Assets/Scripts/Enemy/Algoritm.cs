using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Algoritm : MonoBehaviour
{
    private ShotDirection track;
    public float speedV;
    private float gravity = Physics.gravity.y;
    public float anglesRadian;
    private void Awake()
    {
        track = GetComponent<ShotDirection>();
    }

    private void Update()
    {
        Fire—alculations();
    }
    private void Fire—alculations()
    {
        float x = track.newDirection.magnitude;
        float y = track.direction.y;
        anglesRadian = (track.titleAngles * Mathf.PI) / 180;
        float v2 = (gravity * x * x) / (2 * (y - Mathf.Tan(anglesRadian) * x) * Mathf.Pow(Mathf.Cos(anglesRadian), 2));
        speedV = Mathf.Sqrt(Mathf.Abs(v2)) + RandomPointer();
    }
    private float RandomPointer() // random
    {
        float randomSpeed = Random.Range(-2, 2); 
        return randomSpeed;
    }
}
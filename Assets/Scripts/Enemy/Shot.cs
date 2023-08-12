using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    [SerializeField] Rigidbody2D _bombPrefab;
    [HideInInspector] public bool isActiveGame = false;
    [HideInInspector] public bool isShotingOnTarget =false;
    private bool isFiring = false;
    private Algoritm mathf;
    private ShotDirection track;
    
    private void Awake()
    {
        track = GetComponentInParent<ShotDirection>();
        mathf = GetComponentInParent<Algoritm>();
    } 
    private void Update()
    {
        if (!isFiring && isActiveGame)
        {  
            isFiring = true;
            StartCoroutine(ShotCoroutine()); 
        } 
    }
    private void ShotOnTarget()
    {
        Rigidbody2D newBomb = Instantiate(_bombPrefab, track.pointer.position, track.pointer.rotation) as Rigidbody2D;
        Vector2 velocity = track.pointer.up * mathf.speedV;
        newBomb.velocity = velocity;
        newBomb.AddTorque(Random.Range(-8f, 8f)); 
        isShotingOnTarget = true;
    }
    private IEnumerator ShotCoroutine()
    {
        yield return new WaitForSeconds(3);
        if (!isShotingOnTarget)
        { 
            ShotOnTarget();
        }
        isFiring = false; 
    }
}
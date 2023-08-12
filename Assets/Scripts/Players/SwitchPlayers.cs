using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchPlayers : MonoBehaviour
{ 
    [SerializeField]private Throwing throwingPlayer;
    [SerializeField]private Shot shotEnemy; 
    private void Awake()
    {
        throwingPlayer.isActiveGame = true;
        shotEnemy.isActiveGame = false;
    }   
    private void Update()
    {
        if (throwingPlayer.isShooting)
        { 
            shotEnemy.isActiveGame = true;
            throwingPlayer.isActiveGame = false;
            throwingPlayer.isShooting = false;

        }
        else if (shotEnemy.isShotingOnTarget)
        {
            shotEnemy.isActiveGame = false;
            shotEnemy.isShotingOnTarget = false;
            StartCoroutine(StartPlayerCoroutine());
            StartCoroutine(StartEnemyCoroutine());
        } 
    }  
    private IEnumerator StartPlayerCoroutine()
    {
        yield return new WaitForSeconds(3);
        throwingPlayer.isActiveGame = true; 
    }
    private IEnumerator StartEnemyCoroutine()
    {
        yield return new WaitForSeconds(20);
        throwingPlayer.isActiveGame = false;
        throwingPlayer.isShooting = false;
        shotEnemy.isActiveGame = true;
    }
}

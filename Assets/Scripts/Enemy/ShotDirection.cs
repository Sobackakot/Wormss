 
using UnityEngine;

public class ShotDirection : MonoBehaviour
{
    [SerializeField] public Transform enemySprite;
    [SerializeField] public Transform gunSprite;
    [SerializeField] public Transform pointer;
    [SerializeField] public Transform target;
    [SerializeField] public float titleAngles;

    public Vector3 direction;
    public Vector3 newDirection;
    private float directionX;

    private void Update()
    {
        NewDirection(directionX);
        FlipBody(newDirection.x);
    }
    private void NewDirection(float directionX)
    {
        direction = target.position - transform.position;
        newDirection = new Vector3(direction.x, 0.0f, 0.0f);
        if (directionX < 0)
            pointer.rotation = Quaternion.Euler(0, 0, -titleAngles);
        else
            pointer.rotation = Quaternion.Euler(0, 0, titleAngles);
    }
    private void FlipBody(float newDirection)
    {
        if (newDirection != 0)
        {
            directionX = Mathf.Abs(enemySprite.localScale.x) * (newDirection > 0 ? -1 : 1);
            enemySprite.localScale = new Vector3(directionX, 1f, 1f);    
        }
    }
}
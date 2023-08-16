using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class DeadArea : MonoBehaviour
{
    private void Reset()
    {
        GetComponent<BoxCollider2D>().isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Worm worm))
        {
            worm.Dead();
        }
    }

}

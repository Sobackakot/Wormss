using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCntroller : MonoBehaviour
{
    [SerializeField] private Worm _worm;

    private void Update()
    {
        _worm.Jump(Input.GetKeyDown(KeyCode.Space));
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        _worm.Move(horizontal);
    }

}

using UnityEngine;
using System;

public abstract class SwitchEntity : MonoBehaviour
{
    public event Action<SwitchEntity> OnComplite;

    public abstract void Enter();

    public abstract void Exit();

    protected void CompliteSteap()
    {
        OnComplite?.Invoke(this);
    } 
}

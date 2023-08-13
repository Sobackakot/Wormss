using UnityEngine;

public abstract class SwitchEntity : MonoBehaviour
{
    public event System.Action<SwitchEntity> OnComplite;

    public abstract void Enter();

    public abstract void Exit();

    protected void CompliteSteap()
    {
        OnComplite?.Invoke(this);
    }

}

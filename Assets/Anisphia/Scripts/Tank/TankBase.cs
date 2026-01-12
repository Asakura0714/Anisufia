using UnityEngine;

public class TankBase : MonoBehaviour
{
    public virtual void Setup()
    {

    }

    protected virtual void OnMove(Vector2 moveDir)
    {
    }
    protected virtual void OnAim(Vector2 aimiDir)
    {
    }

    protected virtual void OnFire()
    {
    }

    protected virtual void OnMine()
    {
    }
}

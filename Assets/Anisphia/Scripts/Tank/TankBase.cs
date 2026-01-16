using UnityEngine;
using UnityEngine.UIElements;

public class TankBase : MonoBehaviour
{
    public virtual void Setup()
    {

    }

    protected virtual void OnMove(Vector2 moveDir)
    {
        var rot = transform.rotation;
        var add = 0.01f;

        if (Mathf.Abs(rot.y) != 90f)
        {
            if (moveDir.x >= 0f)
            {
                rot.y += add;
            }
            else if (moveDir.x <= 0f)
            {
                rot.y -= add;
            }
            else if (moveDir.y >= 0f)
            {

            }
            else
            {

            }
        }
        else
        {
            //var newVec = new Vector3(transform.position.x,);
            //transform.position += newVec;
        }

        transform.rotation = rot;
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

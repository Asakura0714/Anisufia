using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerTank : TankBase
{
    public override void Setup()
    {
        base.Setup();

        //ëÄçÏèÓïÒÇÉZÉbÉg
        AnisphiaMainSystem.Instance.InputManager.SetBindPlayerInput(OnMove, OnAim, OnFire, OnMine);
    }

    private void OnMove(InputAction.CallbackContext actionMove)
    {
        OnMove();
    }

    private void OnAim(InputAction.CallbackContext actionAim)
    {
        OnAim();
    }

    private void OnFire(InputAction.CallbackContext actionFire)
    {
        OnFire();
    }

    private void OnMine(InputAction.CallbackContext actionMire)
    {
        OnMine();
    }

    protected override void OnMove()
    {
        base.OnMove();
    }
    protected override void OnAim()
    {
        base.OnAim();
    }

    protected override void OnFire()
    {
        base.OnFire();
    }
    protected override void OnMine()
    {
        base.OnMine();
    }
}

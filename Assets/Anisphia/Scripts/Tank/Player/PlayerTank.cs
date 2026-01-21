using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerTank : TankBase
{
    private enum EMoveState
    {
        Idle,   //待機
        InputCalc,//計算
        Rotate,//回転
        Move//移動
    }
    public override void Setup()
    {
        base.Setup();

        //操作情報をセット
        AnisphiaMainSystem.Instance.InputManager.SetBindPlayerInput(OnMove,OnAim,OnFire,OnMine);
    }

    private void OnFire(InputAction.CallbackContext actionFire)
    {
        OnFire();
    }

    private void OnMine(InputAction.CallbackContext actionMire)
    {
        OnMine();
    }

    protected override void OnMove(Vector2 moveDir)
    {
        if (moveDir != Vector2.zero)
        {
            Debug.Log($"{moveDir}");
            base.OnMove(moveDir);
        }
    }
    protected override void OnAim(Vector2 moveDir)
    {
        if (moveDir != Vector2.zero)
        {
            base.OnAim(moveDir);
            //Debug.Log("Player Aim");
        }
    }

    protected override void OnFire()
    {
        base.OnFire();
        //Debug.Log("Player Fire");
    }
    protected override void OnMine()
    {
        base.OnMine();
        //Debug.Log("Player Mine");
    }
}

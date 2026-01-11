using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : ManagerBase
{
    public InputControl _control;

    public override void Setup()
    {
        _control = new InputControl();
        SetEnable(true);
    }

    public void SetBindPlayerInput(Action<InputAction.CallbackContext> actionMove,
                                   Action<InputAction.CallbackContext> actionAim,
                                   Action<InputAction.CallbackContext> actionFire,
                                   Action<InputAction.CallbackContext> actionMine)
    {
        if (_control == null) return;

        //プレイヤーの挙動をセット
        var player = _control.Player;
        player.Move.performed += actionMove;
        player.Aim.performed += actionAim;
        player.Fire.performed += actionFire;
        player.Mine.performed += actionMine;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="enable"></param>
    public void SetEnable(bool enable)
    {
        if(enable)
        {
            _control.Enable();
        }
        else
        {
            _control.Disable();
        }
    }

    public override void OnDelete()
    {
        
    }
}

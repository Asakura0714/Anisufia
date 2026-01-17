using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Anis.Input
{
    /// <summary>
    /// 接続されている入力
    /// </summary>
    public enum EDeviceType
    {
        None,
        KeyboradMouse,
        Gamepad,
    }

    public class InputManager : ManagerBase
    {
        private InputControl _control;

        private Action<Vector2> _playerMove;
        private Action<Vector2> _playerAim;

        public EDeviceType CurrentDevice { get; private set; }

        public override void Setup()
        {
            _control = new InputControl();
            SetEnable(true);
        }

        public void SetBindPlayerInput(Action<Vector2> moveAxis,
                                       Action<Vector2> aimAxis,
                                       Action<InputAction.CallbackContext> actionFire,
                                       Action<InputAction.CallbackContext> actionMine)
        {
            if (_control == null) return;

            _playerMove += moveAxis;
            _playerAim += aimAxis;

            //プレイヤーの挙動をセット
            var player = _control.Player;
            player.Fire.performed += actionFire; 
            player.Mine.performed += actionMine;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="enable"></param>
        public void SetEnable(bool enable)
        {
            if (enable)
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

        public override void OnUpdate()
        {
            //プレイヤーの移動入力を監視する
            bool Moveflg = _control.Player.Move.IsPressed();
            if (Moveflg)
            {
                Vector2 axis = _control.Player.Move.ReadValue<Vector2>();
                _playerMove?.Invoke(axis);
            }

            //プレイヤーのAim入力を監視する
            bool AimFlg = _control.Player.Aim.IsPressed();
            if (AimFlg)
            {
                Vector2 axis = _control.Player.Aim.ReadValue<Vector2>();
                _playerAim?.Invoke(axis);
            }
        }
    }
}

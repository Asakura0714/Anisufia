using System;
using UnityEditor.ShaderGraph;
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

    public enum EEnableInputType
    {
        Player,
        UI
    }

    public class InputManager : ManagerBase
    {
        private InputControl _control;

        private Action<Vector2> _playerMoveAction;
        private Action<Vector2> _playerAimAction;
        private Action<InputAction.CallbackContext> _playerFireAction;
        private Action<InputAction.CallbackContext> _playerMineAction;
        private Action<InputAction.CallbackContext> _playerPauseAction;

        public EDeviceType CurrentDevice { get; private set; }

        public override void Setup()
        {
            _control = new InputControl();

            _control.Player.Fire.performed  += (content => _playerFireAction?.Invoke(content));
            _control.Player.Mine.performed  += (content => _playerMineAction?.Invoke(content));
            _control.Player.Pause.performed += (content => _playerPauseAction?.Invoke(content));

        }

        public void SetBindPlayerInput(Action<Vector2> moveAxis,
                                       Action<Vector2> aimAxis,
                                       Action<InputAction.CallbackContext> actionFire,
                                       Action<InputAction.CallbackContext> actionMine)
        {
            if (_control == null)
            {
                return;
            }

            //スティックとか十字キーのBind
            _playerMoveAction = moveAxis;

            //Aiｍ
            _playerAimAction = aimAxis;

            //FIre
            _playerFireAction = actionFire;

            //Mine
            _playerMineAction = actionMine;

        }

        public void SetBindPause(Action<InputAction.CallbackContext> actionPause)
        {
            if (_control == null)
            {
                return;
            }

            _playerPauseAction = actionPause;
        }

        /// <summary>
        /// 有効タイプを設定
        /// </summary>
        /// <param name="enable"></param>
        public void SetEnableInputAction(EEnableInputType type)
        {
            switch (type)
            {
                case EEnableInputType.Player:
                    {
                        //プレイヤーの操作を有効
                        _control.Player.Enable();

                        //UIの操作を無効
                        _control.UI.Disable();
                    }
                    break;
                case EEnableInputType.UI:
                    {
                        //プレイヤーの操作を無効
                        _control.Player.Disable();

                        //UIの操作を有効
                        _control.UI.Enable();
                    }
                    break;
                default:
                    break;
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
                _playerMoveAction?.Invoke(axis);
            }

            //プレイヤーのAim入力を監視する
            bool AimFlg = _control.Player.Aim.IsPressed();
            if (AimFlg)
            {
                Vector2 axis = _control.Player.Aim.ReadValue<Vector2>();
                _playerAimAction?.Invoke(axis);
            }
        }
    }
}

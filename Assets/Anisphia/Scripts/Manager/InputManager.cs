using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;

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

        private float _deadzone = 0.15f;

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
            Vector2 leftAxis = _control.Player.Move.ReadValue<Vector2>();
            if (Moveflg && IsOverDeadZone(leftAxis))
            {
                _playerMoveAction?.Invoke(leftAxis.normalized);
            }

            //放置だとnullになる
            if (_control.Player.Aim.activeControl == null)
            {
                return;
            }

            bool isMouse = _control.Player.Aim.activeControl.device is Mouse;

            Vector2 rightAxis = _control.Player.Aim.ReadValue<Vector2>();
            if (isMouse)
            {
                //プレイヤーの入力へ渡す
                _playerAimAction?.Invoke(rightAxis.normalized);
            }
            else
            {
                //DeadZoneを超えないと弾く
                if (IsOverDeadZone(rightAxis) == false)
                {
                    return;
                }

                //プレイヤーの入力へ渡す
                _playerAimAction?.Invoke(rightAxis.normalized);
            }
        }


        /// <summary>
        /// 入力のDeadZoneを判定する
        /// </summary>
        /// <param name="axis"></param>
        /// <returns></returns>
        private bool IsOverDeadZone(Vector2 axis)
        {
            bool isOverX = Mathf.Abs(axis.x) > _deadzone;
            bool isOverY = Mathf.Abs(axis.y) > _deadzone;

            return isOverX || isOverY;
        }
    }
}

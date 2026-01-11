using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using Cysharp.Threading.Tasks;
using System;
using UniRx;

public class EZSaveTest
{
    public int v = 0;
    public string s = "トラ！";
}

public class DebugInput : MonoBehaviour
{
    private enum EInputDeviceType
    {
        None = 0,
        KeyboardMouse,
        Gamepad,
    }

    [SerializeField] private TextMeshProUGUI _debugText = default;

    InputControl control;

    EZSaveTest eZSaveTest = new();

    EInputDeviceType _currentInputDevice;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    private void Move_performed(InputAction.CallbackContext context)
    {
        SetInputDevice(context.control.device);

        var inputAxis = context.ReadValue<Vector2>();
        Debug.Log($"Move : {inputAxis}");
    }

    private void Aim_performed(InputAction.CallbackContext context)
    {
        SetInputDevice(context.control.device);

        var inputAxis = context.ReadValue<Vector2>();
        //Debug.Log($"Aim : {inputAxis}");
    }

    private void Mine_performed(InputAction.CallbackContext context)
    {
        SetInputDevice(context.control.device);

        //Debug.Log("OnMine");
    }

    private void Fire_performed(InputAction.CallbackContext context)
    {
        SetInputDevice(context.control.device);


        var saveData = new EZSaveTest();
        ES3.LoadInto<EZSaveTest>("DebugEZSave", saveData);


        //Debug.Log($"V : {saveData.v} , S : {saveData.s}");
    }

    /// <summary>
    /// 使用するデバイスをセット
    /// </summary>
    /// <param name="inputDevice"></param>
    private void SetInputDevice(InputDevice inputDevice)
    {
        if (inputDevice == null) return;

        if (inputDevice is  Keyboard || inputDevice is Mouse)
        {
            _currentInputDevice = EInputDeviceType.KeyboardMouse;
        }
        else if (inputDevice is Gamepad)
        {
            _currentInputDevice = EInputDeviceType.Gamepad;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log($"現在使用中のデバイス : {_currentInputDevice.ToString()}");

        var str = "";

        if (_currentInputDevice == EInputDeviceType.KeyboardMouse)
        {
            str = "キーボード/マウス";
        }
        else if (_currentInputDevice == EInputDeviceType.Gamepad)
        {
            str = "XBoxコントローラー";
        }

        _debugText.text = str;
    }
}

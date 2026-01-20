using System;
using UnityEngine;
using UnityEngine.UI;

public class AnisButtonBase : MonoBehaviour
{
    private Button _myButton;

    public Action OnClick;

    public void Init(Action onClick)
    {
        _myButton = GetComponent<Button>();

        if(_myButton == null)
        {
            return;
        }

        _myButton.onClick.AddListener(() => onClick?.Invoke());
    }
}

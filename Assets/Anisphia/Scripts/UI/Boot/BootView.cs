using System;
using UnityEngine;

public class BootView : MonoBehaviour
{
    [SerializeField] private AnisButtonBase _aSelectButton = default;
    [SerializeField] private AnisButtonBase _bSelectButton = default;
    [SerializeField] private AnisButtonBase _noControllerButton = default;

    public Action OnClickToTitle;

    public void Init()
    {
        _aSelectButton.Init(OnClickToTitle);
        _bSelectButton.Init(OnClickToTitle);
        _noControllerButton.Init(OnClickToTitle);
    }
}

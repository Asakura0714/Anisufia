using System;
using UnityEngine;

public class MainGameMenuView : ViewBase
{
    [SerializeField] private AnisButtonBase _quitBtn = default;

    public Action OnClickQuitAction;

    public override void InitView()
    {
        _quitBtn.Init(OnClickQuitAction);
    }
}

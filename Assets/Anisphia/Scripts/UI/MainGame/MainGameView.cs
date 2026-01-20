using System;
using UnityEngine;

public class MainGameView : MonoBehaviour
{
    [SerializeField] private AnisButtonBase _quitBtn = default;

    public Action OnClickQuitAction;

    public void Init()
    {
        _quitBtn.Init(OnClickQuitAction);
    }
}

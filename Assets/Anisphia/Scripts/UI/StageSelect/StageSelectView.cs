using System;
using UnityEngine;

public class StageSelectView : MonoBehaviour
{
    private AnisButtonBase[] _anisButtonList;

    public Action OnClickStageButtonAction;

    public void Init()
    {
        _anisButtonList = null;
        _anisButtonList = GetComponentsInChildren<AnisButtonBase>();

        if (_anisButtonList.Length == 0)
        {
            return;
        }

        foreach (var button in _anisButtonList)
        {
            if (button != null)
            {
                button.Init(OnClickStageButtonAction);
            }
        }
    }
}

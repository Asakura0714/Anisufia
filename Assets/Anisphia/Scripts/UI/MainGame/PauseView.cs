using System;
using UnityEngine;

public class PauseView : ViewBase
{
    [SerializeField] private AnisButtonBase _resumeButton = default;
    [SerializeField] private AnisButtonBase _retryButton = default;
    [SerializeField] private AnisButtonBase _stageSelectButton = default;
    [SerializeField] private AnisButtonBase _settingButton = default;

    public Action OnClickResumeAction;
    public Action OnClickRetryAction;
    public Action OnClickStageSelectAction;
    public Action OnClickSettingAction;

    public override void InitView()
    {
        _resumeButton.Init(OnClickResumeAction);
        _retryButton.Init(OnClickRetryAction);
        _stageSelectButton.Init(OnClickStageSelectAction);
        _settingButton.Init(OnClickSettingAction);
    }

    public override AnisButtonBase FirstSelectedGameObject()
    {
        return _resumeButton;
    }
}

using System;
using UnityEngine;

public class TitlePresenter : PresenterBase
{
    [SerializeField] private TitleView  _view = default;

    public Action OnStageSelectAction;
    public Action OnSettingAction;
    public Action OnGameExitAction;

    public override void InitPresenter()
    {
        _view.OnClickStageSelectAction = () => OnStageSelectAction?.Invoke();
        _view.OnClickSettingAction += () => OnSettingAction?.Invoke();
        _view.OnClickExitAction += () =>  OnGameExitAction?.Invoke();

        _view.Init();
    }
}

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using Anis.Input;
using System;

public class MainGamePresenter : MonoBehaviour
{
    [SerializeField] private MainGameMenuView _menuView = default;
    [SerializeField] private PauseView _pauseView = default;

    public Action<InputAction.CallbackContext> OnClickPauseAction;
    public Action OnClickResumeAction;
    public Action OnClickRetryAction;
    public Action OnClickStageSelectAction;
    public Action OnClickSettingAction;
    public Action OnClickQuitGame;

    public GameObject GetSelectedGameObject => _pauseView.FirstSelectedGameObject().gameObject;

    public void Init()
    {
        EventSystem.current.SetSelectedGameObject(null);

        //ポーズを開く
        AnisphiaMainSystem.Instance.InputManager.SetBindPause(OnClickPauseAction);

        //ゲーム再開
        _pauseView.OnClickResumeAction = () => OnClickResumeAction?.Invoke(); ;

        //ゲームやりおなし
        _pauseView.OnClickRetryAction = () => OnClickRetryAction?.Invoke();

        //ステージ選択へ
        _pauseView.OnClickStageSelectAction = () => OnClickStageSelectAction?.Invoke(); ;

        //設定画面へ
        _pauseView.OnClickSettingAction = () => OnClickSettingAction?.Invoke();

        //ゲーム終了
        _menuView.OnClickQuitAction = () => OnClickQuitGame?.Invoke();

        _pauseView.InitView();
        _menuView.InitView();

        //ポーズ画面を非表示
        SetActivePauseScreen(false);
    }

    /// <summary>
    /// Pause画面の表示切り替え
    /// </summary>
    /// <param name="isActive"></param>
    public void SetActivePauseScreen(bool isActive)
    {
        _pauseView.SetActiveView(isActive);
    }
}

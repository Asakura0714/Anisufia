using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using Anis.Input;
using System;

public class MainGamePresenter : MonoBehaviour
{
    [SerializeField] private MainGameMenuView _menuView = default;
    [SerializeField] private PauseView _pauseView = default;

    public void Init()
    {


        EventSystem.current.SetSelectedGameObject(null);

        BindsPause();

        _pauseView.InitView();
        _pauseView.SetActiveView(false);

        _menuView.OnClickQuitAction += OnQuit;

        _menuView.InitView();

    }

    private void OnClickResumeAction()
    {
        Debug.Log("ゲーム再開");

        _pauseView.SetActiveView(false);

        //PlayerのInputActionを有効にする
        AnisphiaMainSystem.Instance.InputManager.SetEnableInputAction(EEnableInputType.Player);
    }

    private void OnClickRetryAction()
    {
        Debug.Log("ゲームやり直し");
        AnisphiaMainSystem.Instance.SceneManager.LoadScene(Anis.Scene.SceneManager.ESceneType.MainGame);
    }

    private void OnClickSelectStage()
    {
        Debug.Log("ステージ選択へ");

        //ステージ選択へ
        AnisphiaMainSystem.Instance.SceneManager.LoadScene(Anis.Scene.SceneManager.ESceneType.StageSelect);
    }

    private void OnClickSettingAction()
    {
        Debug.Log("設定画面を開くよ");
    }

    public void OnPause(InputAction.CallbackContext pauseContext)
    {
        Debug.Log("ポーズ");

        //ポーズON
        _pauseView.SetActiveView(true);

        //ポーズを開いた時にFocusを行う
        EventSystem.current.SetSelectedGameObject(_pauseView.FirstSelectedGameObject().gameObject);

        //UIのInputActionを有効にする
        AnisphiaMainSystem.Instance.InputManager.SetEnableInputAction(EEnableInputType.UI);
    }

    private void OnQuit()
    {
        AnisphiaMainSystem.Instance.AppQuit();
    }

    private void BindsPause()
    {
        //ゲーム再開
        _pauseView.OnClickResumeAction += OnClickResumeAction;

        //ゲームやりおなし
        _pauseView.OnClickRetryAction += OnClickRetryAction;

        //ステージ選択へ
        _pauseView.OnClickStageSelectAction += OnClickSelectStage;

        //設定画面へ
        _pauseView.OnClickSettingAction += OnClickSettingAction;
    }
}

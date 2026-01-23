using UnityEngine;

public class SceneTitle : SceneBase
{
    [SerializeField] private TitlePresenter _presenter = default;

    public override void Awake()
    {
        InitScene();
    }

    public override void InitScene()
    {
        _presenter.InitPresenter();

        _presenter.OnStageSelectAction = OnClickStageSelect;
        _presenter.OnSettingAction = OnClickSettting;
        _presenter.OnGameExitAction = OnClickGameExit;
    }

    private async void OnClickStageSelect()
    {
        Debug.Log("ステージ選択");
        //AnisphiaMainSystem.Instance.SceneManager.LoadScene(Anis.Scene.SceneManager.ESceneType.StageSelect);

        await AnisphiaMainSystem.Instance.SceneManager.ChangeSceneAync(Anis.Scene.SceneManager.ESceneType.StageSelect);

        Debug.Log("ステージ読み込み完了");
    }

    private void OnClickSettting()
    {
        Debug.Log("設定画面");
    }

    private void OnClickGameExit()
    {
        Debug.Log("ゲームを終了します");

        AnisphiaMainSystem.Instance.AppQuit();
    }
}

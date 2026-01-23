using UnityEngine;

public class SceneTitle : SceneBase
{
    [SerializeField] private TitlePresenter _presenter = default;

    //[SerializeField] private ScreenTransition _fadeIn = default;
    [SerializeField] private TransitionController _fadeController = default;

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

        _fadeController.FadeIn.Setup();
    }

    private void OnClickStageSelect()
    {
        Debug.Log("ステージ選択");
        AnisphiaMainSystem.Instance.SceneManager.LoadScene(Anis.Scene.SceneManager.ESceneType.StageSelect);
    }

    private void OnClickSettting()
    {
        Debug.Log("設定画面");

        _fadeController.FadeIn.PlayTranssition(() =>
        {
            Invoke("ToStage", 3f);
        });
    }

    private void OnClickGameExit()
    {
        Debug.Log("ゲームを終了します");

        AnisphiaMainSystem.Instance.AppQuit();
    }

    private void ToStage()
    {
        _fadeController.FadeIn.gameObject.SetActive(false);

        _fadeController.FadeOut.Setup();

        _fadeController.FadeOut.PlayTranssition(() =>
        {
            //_fadeController.FadeOut.enabled = false;
        });
    }
}

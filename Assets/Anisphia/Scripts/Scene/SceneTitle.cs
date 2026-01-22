using UnityEngine;

public class SceneTitle : SceneBase
{
    [SerializeField] private TitlePresenter _presenter = default;

    [SerializeField] private ScreenTransition screenTransition = default;

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

        //要調整くっそわかりにくい
        screenTransition.Setup(ScreenTransition.EFadeType.FadeIn,
                       () =>
                       {

                       });
    }

    private void OnClickStageSelect()
    {
        Debug.Log("ステージ選択");
        AnisphiaMainSystem.Instance.SceneManager.LoadScene(Anis.Scene.SceneManager.ESceneType.StageSelect);
    }

    private void OnClickSettting()
    {
        Debug.Log("設定画面");


        screenTransition.OnStart(ScreenTransition.EFadeType.FadeOut);
    }

    private void OnClickGameExit()
    {
        Debug.Log("ゲームを終了します");

        AnisphiaMainSystem.Instance.AppQuit();
    }
}

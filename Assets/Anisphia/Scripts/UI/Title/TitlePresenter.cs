using UnityEngine;

public class TitlePresenter : MonoBehaviour
{
    [SerializeField] private TitleView  _view = default;

    void Start()
    {
        _view.OnClickStageSelectAction += OnClickStageSelect;
        _view.OnClickSettingAction += OnClickSettting;
        _view.OnClickExitAction += OnClickGameExit;

        _view.Init();
    }


    private void OnClickStageSelect()
    {
        Debug.Log("ステージ選択");
        AnisphiaMainSystem.Instance.SceneManager.LoadScene(Anis.Scene.SceneManager.ESceneType.StageSelect);
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

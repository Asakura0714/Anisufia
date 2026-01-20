using UnityEngine;

public class TitlePresenter : MonoBehaviour
{
    [SerializeField] private TitleView  _titleView = default;

    void Start()
    {
        _titleView.OnClickStageSelectAction += OnClickStageSelect;
        _titleView.OnClickSettingAction += OnClickSettting;
        _titleView.OnClickExitAction += OnClickGameExit;

        _titleView.Init();
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

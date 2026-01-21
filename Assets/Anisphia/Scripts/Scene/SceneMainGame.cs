using Anis.Input;
using UnityEngine;

public class SceneMainGame : SceneBase
{
    [SerializeField] private MainGamePresenter _uiPresenter = default;
    [SerializeField] private PlayerTank _playerTank = default;

    public override void Awake()
    {
        InitScene();
    }

    public override void InitScene()
    {
        _playerTank.Setup();

        //ポーズをセット
        AnisphiaMainSystem.Instance.InputManager.SetBindPause(_uiPresenter.OnPause);

        //Playerの操作情報はBinidしたので、Playerへ切り替える
        AnisphiaMainSystem.Instance.InputManager.SetEnableInputAction(EEnableInputType.Player);

        //UI初期化
        _uiPresenter.Init();
    }
}

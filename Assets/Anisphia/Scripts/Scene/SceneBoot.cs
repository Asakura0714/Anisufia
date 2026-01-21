using UnityEngine;
using Anis.Input;
using UnityEngine.EventSystems;

public class SceneBoot : SceneBase
{
    [SerializeField] private BootPresenter _presenter = default;

    public override void Awake()
    {
        InitScene();
    }

    public override void InitScene()
    {
        _presenter.InitPresenter();

        //UI‚ð—LŒø‚É‚·‚é
        AnisphiaMainSystem.Instance.InputManager.SetEnableInputAction(EEnableInputType.UI);
    }
}

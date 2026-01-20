using UnityEngine;

public class BootPresenter : MonoBehaviour
{
    [SerializeField] private BootView _view = default;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _view.OnClickToTitle += ToTitle;

        _view.Init();
    }

    private void ToTitle()
    {
        AnisphiaMainSystem.Instance.SceneManager.LoadScene(Anis.Scene.SceneManager.ESceneType.Title);
    }
}

using UnityEngine;

public class MainGamePresenter : MonoBehaviour
{
    [SerializeField] private MainGameView _view = default;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _view.OnClickQuitAction += OnQuit;

        _view.Init();
    }

    private void OnQuit()
    {
        AnisphiaMainSystem.Instance.AppQuit();
    }
}

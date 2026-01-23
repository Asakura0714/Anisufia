using UnityEngine;

public class CommonUIManager : ManagerBase
{
    private const string SCENE_CANVAS_TAG_NAME = "SceneCanvas";
    private const string DIALOG_CANVAS_TAG_NAME = "DialogCanvas";

    private Canvas _sceneCanvas;
    private Canvas _dialoagCanvas;

    public override void Setup()
    {
        //FindCanvas();
    }
    public override void OnUpdate()
    {
        
    }
    public override void OnDelete()
    {
        if (_sceneCanvas != null)
        {
            _sceneCanvas = null;
        }

        if (_dialoagCanvas != null)
        {
            _dialoagCanvas = null;
        }
    }

    public void FindCanvas()
    {
        var go1 = GameObject.FindGameObjectWithTag(SCENE_CANVAS_TAG_NAME);
        _sceneCanvas = go1.GetComponent<Canvas>();


        var go2 = GameObject.FindGameObjectWithTag(DIALOG_CANVAS_TAG_NAME);
        _dialoagCanvas = go2.GetComponent<Canvas>();
    }
}

using UnityEngine;

public class AnisphiaMainSystem : MonoBehaviour
{
    /// <summary>
    /// アプリのセットアップが完了したか？
    /// </summary>
    public static bool AppInitialized { get; private set; }

    /// <summary>
    /// インスタンス
    /// </summary>
    public static AnisphiaMainSystem Instance { get; private set; }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void AppEntryPoint()
    {
        var go = new GameObject("AnisphiaMainSystem");
        var system = go.AddComponent<AnisphiaMainSystem>();

        DontDestroyOnLoad(go);
        Instance = system;
        Instance.Setup();
    }

    private void Setup()
    {
        //TODO : セーブデータを読み込む
        //TODO : Inputdataを読み込む

        Application.quitting += AppQuit;

        //神、準備完了
        AppInitialized = true;
    }

    private static void AppQuit()
    {

    }
}

using UnityEngine;

public class AppStartupInitializer : MonoBehaviour
{
    /// <summary>
    /// アプリのセットアップが完了したか？
    /// </summary>
    public static bool AppInitialized { get; private set; }

    /// <summary>
    /// アプリ開始時(シーンの前に呼ばれる)
    /// </summary>
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]  
    private static void Initialize()
    {
        //開始時の処理は終わってる？
        if (AppInitialized) return;

        //空のGameObjectに自分自身をアタッチ
        new GameObject("initializerEmptyObj")
            .AddComponent<AppStartupInitializer>()
            .Setup();
    }


    private void Setup()
    {
        //入力データを読み込み
        InputManager.Instance.Setup();

        //TODO : セーブデータを読み込む

        //自分自身を消しまーす！
        Destroy(gameObject);

        //アプリのセットアップが完了
        AppInitialized = true;
    }
}

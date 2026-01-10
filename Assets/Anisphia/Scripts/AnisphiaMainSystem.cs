using System.Collections.Generic;
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

    public enum EManagerType
    {
        Input,
        SaveData,
    }

    private Dictionary<EManagerType, ManagerBase> _managerMap = new Dictionary<EManagerType, ManagerBase>();

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
        CreateManager<InputManager>(EManagerType.Input);
        CreateManager<SaveDataManager>(EManagerType.SaveData);


        Application.quitting += AppQuit;

        //神、準備完了
        AppInitialized = true;
    }

    private void CreateManager<T>(EManagerType type)where T : ManagerBase
    {
        //クラス名をオブジェクト名に設定
        var go = new GameObject(typeof(T).Name);
        if (go == null) return;

        //クラス生成
        ManagerBase manaBase = go.AddComponent<T>();
        if (manaBase == null) return;

        //初期化開始
        manaBase.Setup();

        //子供として設定
        manaBase.transform.SetParent(this.transform);

        //全体で保持
        DontDestroyOnLoad(go);

        //管理
        _managerMap.Add(type, manaBase);
    }

    private void AppQuit()
    {
        _managerMap.Clear();

        if (Instance != null)
        {
            Instance = null;
        }
    }
}

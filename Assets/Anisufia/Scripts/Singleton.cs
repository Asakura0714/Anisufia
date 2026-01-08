using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;


    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                CreateInstance();
            }

            return _instance;
        }
    }

    private static void CreateInstance()
    {
        if (_instance != null) return;

        //Šù‚É“¯‚¶•¨‚ªƒV[ƒ“‚È‚¢‚É‘¶İ‚·‚é
        _instance = Object.FindFirstObjectByType<T>();
        if (_instance != null) return;


        var obj = new GameObject(typeof(T).Name);
        _instance = obj.AddComponent<T>();
        DontDestroyOnLoad(obj);
    }


    protected virtual void Awake()
    {
        //Šù‚É‘¶İÏ‚İ
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }

        //Œ^•ÏŠ·
        _instance = this as T;

        DontDestroyOnLoad(gameObject);
    }

    public virtual void Setup()
    {

    }
}

using System.Collections;
using UnityEngine;
using UnityEngine.Scripting;

public class SaveDataManager : ManagerBase
{

    public override void Setup()
    {

    }

    public void Save()
    {
        ES3.Save<string>("TestSave","SSS");
    }

    public void Load()
    {
       var v =ES3.Load<string>("TestSave");

        Debug.Log($"Load : {v}");
    }
}

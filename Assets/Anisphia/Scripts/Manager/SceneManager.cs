using System.Collections.Generic;
using UnityEngine;
using UnitySceneManager = UnityEngine.SceneManagement.SceneManager;

namespace Anis.Scene
{
    public class SceneManager : ManagerBase
    {
        public enum ESceneType
        {
            Boot,
            Title,
            StageSelect,
            MainGame,
        }
    
        private Dictionary<ESceneType, string> sceneList = new Dictionary<ESceneType, string>()
        {
            { ESceneType.Boot,"Boot"},
            { ESceneType.Title,"Title"},
            { ESceneType.StageSelect,"StageSelect"},
            { ESceneType.MainGame,"MainGame"}
        };
    
        public ESceneType CurrentSceneType { get; private set; }
    
    
        public void LoadScene(ESceneType sceneType)
        {
            CurrentSceneType = sceneType;

            var name = sceneList[sceneType];
            UnitySceneManager.LoadScene(name);
        }
    
        public override void Setup()
        {
        }
    
        public override void OnDelete()
        {
            
        }
    }
}

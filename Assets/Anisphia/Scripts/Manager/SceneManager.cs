using Cysharp.Threading.Tasks;
using System;
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

        /// <summary>
        /// ÉVÅ[ÉìñºÇéÊìæÇ∑ÇÈ
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private string GetSceneName(ESceneType type) => sceneList[type];

        public ESceneType CurrentSceneType { get; private set; }
    
    
        public void LoadScene(ESceneType sceneType)
        {
            CurrentSceneType = sceneType;

            UnitySceneManager.LoadScene(GetSceneName(sceneType));
        }

        public async UniTask ChangeSceneAync(ESceneType sceneType)
        {
            await UnitySceneManager.LoadSceneAsync(GetSceneName(sceneType));

            await UniTask.Delay(TimeSpan.FromSeconds(10f));
        }
    
        public override void Setup()
        {
        }
    
        public override void OnDelete()
        {
            
        }
    }
}

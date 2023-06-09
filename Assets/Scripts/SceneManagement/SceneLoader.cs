using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using WasderGQ.Sudoku.Enums;
using WasderGQ.Sudoku.Generic;

namespace WasderGQ.Sudoku.SceneManagement
{
    public class SceneLoader : Singleton<SceneLoader>
    {
        private AsyncOperation _nextSceneLoadOperation;

        private void Start()
        {
            UnityEngine.SceneManagement.SceneManager.activeSceneChanged += ActiveScenesChanged;
            // LoadFirstScene();
        }

        private void ActiveScenesChanged(Scene current, Scene next) => Debug.Log("Active scene has been changed: " + current.name + "-->" + next.name);

        private void OnDestroy()
        {

        }


        private void LoadFirstScene()
        {
            LoadScene(EnumScenes.LogoScene);
        }

        public void LoadScene(EnumScenes enumSceneToLoad)
        {
            StartCoroutine(LoadSceneRoutine(enumSceneToLoad));
        }

        private IEnumerator LoadSceneRoutine(Enums.EnumScenes enumSceneName)
        {
            //if there are more scene than loading scene, that means there is a scene need to unload.
            if (SceneManager.sceneCount > 1)
            {
                SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex, UnloadSceneOptions.UnloadAllEmbeddedSceneObjects); //unload active scene

            
            }
            _nextSceneLoadOperation = SceneManager.LoadSceneAsync((int)enumSceneName, LoadSceneMode.Additive);
            while (!_nextSceneLoadOperation.isDone)
            {
            
                yield return null;
            }
            SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex((int)enumSceneName));
            Resources.UnloadUnusedAssets();
            yield break;
        }
    
    
    }
}
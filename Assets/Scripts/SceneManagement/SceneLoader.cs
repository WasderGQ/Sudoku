using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
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
            LoadScene(Enums.Scenes.LogoScene);
        }

        public void LoadScene(Enums.Scenes sceneToLoad)
        {
            StartCoroutine(LoadSceneRoutine(sceneToLoad));
        }

        private IEnumerator LoadSceneRoutine(Enums.Scenes sceneName)
        {
            //if there are more scene than loading scene, that means there is a scene need to unload.
            if (SceneManager.sceneCount > 1)
            {
                SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex, UnloadSceneOptions.UnloadAllEmbeddedSceneObjects); //unload active scene

            
            }
            _nextSceneLoadOperation = SceneManager.LoadSceneAsync((int)sceneName, LoadSceneMode.Additive);
            while (!_nextSceneLoadOperation.isDone)
            {
            
                yield return null;
            }
            SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex((int)sceneName));
            Resources.UnloadUnusedAssets();
            yield break;
        }
    
    
    }
}
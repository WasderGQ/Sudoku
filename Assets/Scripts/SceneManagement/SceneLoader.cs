using System.Collections;
using Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class SceneLoader : Singleton<SceneLoader>
{
    private AsyncOperation _nextSceneLoadOperation;

    [SerializeField] private GameObject _uiPanel;
    [SerializeField] private Text _textSlider;
    [SerializeField] private Image _sliderLoading;


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
        LoadScene(Scenes.LogoScene);
    }

    public void LoadScene(Scenes sceneToLoad)
    {
        StartCoroutine(LoadSceneRoutine(sceneToLoad));
    }

    private IEnumerator LoadSceneRoutine(Scenes sceneName)
    {
        //GameEvents.OnSceneLoaderBeginLoad?.Invoke(sceneName.ToString()); //Event

        //Open UI
        /*UpdateProgressUI(0);*/
       // _uiPanel.SetActive(true);

        //if there are more scene than loading scene, that means there is a scene need to unload.
        if (SceneManager.sceneCount > 1)
        {
            SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex, UnloadSceneOptions.UnloadAllEmbeddedSceneObjects); //unload active scene

            //Set loading scene to active scene
            //SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex((int) Scenes.LoadingScene));
        }

        //Load new scene
        _nextSceneLoadOperation = SceneManager.LoadSceneAsync((int)sceneName, LoadSceneMode.Additive);

        //Update UI until finishes
        while (!_nextSceneLoadOperation.isDone)
        {
            /*UpdateProgressUI(_nextSceneLoadOperation.progress);*/
            yield return null;
        }

        /*UpdateProgressUI(_nextSceneLoadOperation.progress);*/

        //Set active newly loaded scene
        SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex((int)sceneName));

        //Close UI
        //_uiPanel.SetActive(false);
        //Optimization
        Resources.UnloadUnusedAssets();

        //GameEvents.OnSceneLoaderEndLoad?.Invoke(sceneName.ToString()); //Event
        yield break;
    }

    /*private void UpdateProgressUI(float progress)
    {
        _sliderLoading.fillAmount = progress;
        _textSlider.text = (int)(progress * 100f) + "%";
    }*/

    public enum Scenes
    {
        LogoScene = 0,
        MainMenuScene = 1,
        GameSceneSudoku = 2
    }
}

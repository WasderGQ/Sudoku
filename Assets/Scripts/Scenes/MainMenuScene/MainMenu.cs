using UnityEngine;
using UnityEngine.UI;
using WasderGQ.Sudoku.SceneManagement;
using WasderGQ.Sudoku.Enums;
namespace WasderGQ.Sudoku.Scenes.MainMenuScene
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private Button Gamemode1;
        [SerializeField] private Button Gamemode2;
        [SerializeField] private Button Gamemode3;
        [SerializeField] private Button Gamemode4;
        [SerializeField] private SO_GameMode GameTypes;
        [SerializeField] private Button StartGame;


        private void Start()
        {
            init();
        }


        void init() 
        {
            EventListener();
        }

        void EventListener()
        {
            Gamemode1.onClick.AddListener(StartGameMode3x3);
            Gamemode2.onClick.AddListener(StartGameMode6x6);
            Gamemode3.onClick.AddListener(StartGameMode9x9);
            Gamemode4.onClick.AddListener(StartGameMode12x12);
            StartGame.onClick.AddListener(StartGameMode9x9);
        }

        private void StartGameMode3x3()
        {
            GameTypes.SetGamemode3x3();
            SceneLoader.Instance.LoadScene(Enums.Scenes.GameSceneSudoku);
        }
        private void StartGameMode6x6()
        {
            GameTypes.SetGamemode6x6();
            SceneLoader.Instance.LoadScene(Enums.Scenes.GameSceneSudoku);
        }
        private void StartGameMode9x9()
        {
            GameTypes.SetGamemode9x9();
            SceneLoader.Instance.LoadScene(Enums.Scenes.GameSceneSudoku);
        }
        private void StartGameMode12x12()
        {
            GameTypes.SetGamemode12x12();
            SceneLoader.Instance.LoadScene(Enums.Scenes.GameSceneSudoku);
        }
    













    }
}

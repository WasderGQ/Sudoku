
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private Button Gamemode1;
    [SerializeField] private Button Gamemode2;
    [SerializeField] private Button Gamemode3;
    [SerializeField] private Button Gamemode4;
    [SerializeField] private SceneScreptableObject GameType;
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
        Gamemode1.onClick.AddListener(GameType.Gamemode3x3);
        Gamemode2.onClick.AddListener(GameType.Gamemode6x6);
        Gamemode3.onClick.AddListener(GameType.Gamemode9x9);
        Gamemode4.onClick.AddListener(GameType.Gamemode12x12);
        StartGame.onClick.AddListener(GameStart);                             



    }

    
    void GameStart()
    {
        SceneManager.LoadScene(1);



    }













}

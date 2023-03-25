
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MB_MenuManager : MonoBehaviour
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
        Gamemode1.onClick.AddListener(GameTypes.Gamemode3x3);
        Gamemode2.onClick.AddListener(GameTypes.Gamemode6x6);
        Gamemode3.onClick.AddListener(GameTypes.Gamemode9x9);
        Gamemode4.onClick.AddListener(GameTypes.Gamemode12x12);
        //StartGame.onClick.AddListener(GameStart);                             



    }

    
    













}

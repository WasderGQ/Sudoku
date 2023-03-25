using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "GameMode", menuName = "ScriptableObjects/GameMode", order = 1)]

public class SO_GameMode : ScriptableObject
{

     private GameModeEnum GameModeEnum;
    
    [SerializeField] private List<MB_Board> _gameBoards;

    
    public void Gamemode3x3()
    {
        GameModeEnum = GameModeEnum.x3;
       // _boards[(int)GameModeEnum.x3].;
        GameStart();
    }
    public void Gamemode6x6()
    {
        GameModeEnum = GameModeEnum.x6;

        GameStart();
    }
    public void Gamemode9x9() // bu modda çalýþ
    {
        GameModeEnum = GameModeEnum.x9;
        //start animastion of loading
        //make a game 2 type make a game first type early maded temp *or make this computer with algoritms

        GameStart();
        
    }
    public void Gamemode12x12()
    {
        GameModeEnum = GameModeEnum.x12;

        GameStart();
    }

    public GameModeEnum TakeGameMode()
    {



        return GameModeEnum;
    }

    async Task<bool> GameStart()
    {

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(1);
        FindDashBoard(asyncLoad.isDone);
        return true; 
        


    }


    async Task<bool> FindDashBoard(bool task)
    {
        try
        {

            _gameBoards.Add(GameObject.FindGameObjectWithTag("BoardZone_6x6").GetComponent<MB_Board>());
            _gameBoards.Add(GameObject.FindGameObjectWithTag("BoardZone_9x9").GetComponent<MB_Board>());
            return true;
        }
        catch
        
        {
            Debug.Log("I cant find Dashboard");

            return false; }
        

    }
    
    void GameMaker9x9()
    {
      //  _gameTable = new int[9,9];
        





















    }
}

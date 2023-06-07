using UnityEngine;
using UnityEngine.SceneManagement;


[CreateAssetMenu(fileName = "GameMode", menuName = "ScriptableObjects/GameMode", order = 1)]

public class SO_GameMode : ScriptableObject
{

    [SerializeField] private GameBoardsEnum GameBoardsEnum;
     
    public void Gamemode3x3()
    {
        GameBoardsEnum = GameBoardsEnum.x3;
        GameStart();
    }
   
    public void Gamemode6x6()
    {
        GameBoardsEnum = GameBoardsEnum.x6;
        GameStart();
    }
    
    public void Gamemode9x9() // bu modda �al��
    {
        GameBoardsEnum = GameBoardsEnum.x9;
        //start animastion of loading
        //make a game 2 type make a game first type early maded temp *or make this computer with algoritms
        GameStart();
        Debug.Log(TakeGameMode());
        
    }
    
    public void Gamemode12x12()
    {
        GameBoardsEnum = GameBoardsEnum.x12;
        GameStart();
    }

     public GameBoardsEnum TakeGameMode()
    {
        return GameBoardsEnum;
    }

    private void GameStart()
    {
        SceneManager.LoadScene((int)ScenesEnum.GameScene);
        
        
        /*AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(1);
        FindDashBoard(asyncLoad.isDone);
        return true; */

    }


   /* async Task<bool> FindDashBoard(bool task)
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
        

    }*/
    
   /* void GameMaker9x9()
    {
      //  _gameTable = new int[9,9];
        




















    
    }*/
}

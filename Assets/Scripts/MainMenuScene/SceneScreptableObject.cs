
using UnityEngine;
[CreateAssetMenu(fileName = "GameMode", menuName = "ScriptableObjects/GameMode", order = 1)]
public class SceneScreptableObject : ScriptableObject
{
    
   [SerializeField] private GameModeEnum GameModeEnum;



    public void Gamemode3x3()
    {
        GameModeEnum = GameModeEnum.x3;
    }
    public void Gamemode6x6()
    {
        GameModeEnum = GameModeEnum.x6;
    }
    public void Gamemode9x9()
    {
        GameModeEnum = GameModeEnum.x9;
    }
    public void Gamemode12x12()
    {
        GameModeEnum = GameModeEnum.x12;
    }

    public GameModeEnum TakeGameMode()
    {



        return GameModeEnum;
    }


}

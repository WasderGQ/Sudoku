using System;
using UnityEngine;
using UnityEngine.UI;

namespace MyNamespace
{
    
}
public class KeyboardKey : MonoBehaviour
{
    [SerializeField] private int _myValue;
    public Button Button { get; private set; }
    public int MyValue
    {
        get => _myValue;
    }
    public void Init()
    {
        SetButton();
    }

    private void SetButton()
    {
        try
        {
            Button = GetComponent<Button>();
        }
        catch (Exception e)
        {
            Debug.LogError($"This keyboard button doesnt have button component!!! {e.Message}");
            
        }

        
        
        
        
        
        
    }
    
    public void DoClickAnimation()
    {
            
            
            
    }



















}

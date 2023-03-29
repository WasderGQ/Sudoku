using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MB_Keyboard : MonoBehaviour
{
    [SerializeField] private List<Button> _myButtons;
    [SerializeField] private MB_KeyboardButton _selectedKeyboardKey;
    [SerializeField] private MB_Zone _selectedZone;




    public void init()
    {
        EventsListner();

    }





    void EventsListner()
    {

        KeyboardButtonsAddListener();


    }



    public void SelectedZoneTaker(MB_Zone takedZone)
    {

        _selectedZone = takedZone;

    }

    private void KeyboardButtonsAddListener()
    {
        foreach (var button in _myButtons)
        {
            button.onClick.AddListener(() => KeyboardValueWriter(button));


        }

    }





    private void KeyboardValueWriter(Button readButton)
    {
        if (_selectedZone != null)
        {
            _selectedZone.WriteValue(readButton.GetComponent<MB_KeyboardButton>().GiveMyValue());
            _selectedZone = null;
        }

        else
        {
            Debug.LogWarning("SelectZone DUDE");


        }



    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MB_Keyboard : MonoBehaviour //MonoBehaviour olmasada olur
{
    [SerializeField] private List<Button> _myButtons;
    [SerializeField] private MB_KeyboardButton _selectedKeyboardKey;
    [SerializeField] private List<MB_Zone> _selectedZones;




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

        _selectedZones.Add(takedZone);
        takedZone.GetComponentInChildren<Image>().color = Color.yellow;

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
        if (_selectedZones != null)
        {
            foreach (var zone in _selectedZones)
            {
                zone.WriteValue(readButton.GetComponent<MB_KeyboardButton>().GiveMyValue());
                zone.GetComponentInChildren<Image>().color =Color.white;
            }

            _selectedZones.Clear();

        }

        else
        {
            Debug.LogWarning("SelectZone DUDE");


        }



    }

}

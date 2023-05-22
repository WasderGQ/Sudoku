using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MyNamespace
{
    
}
public class Keyboard : MonoBehaviour //MonoBehaviour olmasada olur
{
    [SerializeField] private List<Button> _myButtons;
    [SerializeField] private KeyboardButton _selectedKeyboardKey;
    [SerializeField] private List<MB_Zone> _selectedZones;
    [SerializeField] private Board _board;



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
                zone.WriteValue(readButton.GetComponent<KeyboardButton>().GiveMyValue());
                zone.GetComponentInChildren<Image>().color =Color.white;
            }

            _selectedZones.Clear();

        }

        else
        {
            Debug.LogWarning("First select some zone!!");


        }


        private void ZonesButtonAddListener() //Sending to keyboard
        {

            foreach (var parsel in _parselList)
            {
                foreach (var zone in parsel.ZonesInParsel)
                {
                    zone.GetComponent<Button>().onClick.AddListener(() => _keyboard.SelectedZoneTaker(zone.SelectedZone()));
                }

            }


        }
    }

}

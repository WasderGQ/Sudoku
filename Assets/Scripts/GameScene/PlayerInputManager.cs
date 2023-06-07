using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.YamlDotNet.Core.Tokens;
using UnityEngine;
using UnityEngine.UI;

namespace WasderGQ.Sudoku
{
    public class PlayerInputManager : MonoBehaviour
    {
        private LayerMask _interactable;
        [SerializeField] private Keyboard _keyboard;
        private void Update()
        {
            MouseClick();
        }

        private void MouseClick()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Vector3 position = TakeMousePosition();
                RaycastHit raycastHit = RayThrowTakeRaycastHit2D(position);
                Interact(raycastHit);
            }
            
            
        }

        private RaycastHit RayThrowTakeRaycastHit2D(Vector3 postion)
        {
            List<RaycastHit> raycastHitList = new List<RaycastHit>();
            Physics.RaycastAll(postion, Vector3.forward, float.MaxValue, _interactable);
            return raycastHitList[0];
        }

        private Vector3 TakeMousePosition()
        {
            return Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        private void Interact(RaycastHit raycastHit)
        {
            if (raycastHit.collider.CompareTag("Zone"))
            {
                MB_Zone zone = new MB_Zone();
                try
                {
                    zone = raycastHit.collider.GetComponent<MB_Zone>();
                }
                catch 
                {
                    Debug.LogError("There is no !! MB_Zone !! script on the reached GameObject.");
                }
                zone.DoClickAnimation();
                _keyboard.SaveZoneToList(zone);
            }

            if (raycastHit.collider.CompareTag("KeyboardKey"))
            {
                KeyboardKey key = new KeyboardKey();
                try
                {
                    key = raycastHit.collider.GetComponent<KeyboardKey>();
                }
                catch 
                {
                    Debug.LogError("There is no !! KeyboardKey !! script on the reached GameObject.");
                }
                key.DoClickAnimation();
                _keyboard.FillZoneWithValue(key);
            }
            
        }
    }
}

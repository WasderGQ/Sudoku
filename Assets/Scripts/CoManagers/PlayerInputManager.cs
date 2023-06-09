using System;
using System.Collections.Generic;
using UnityEngine;
using WasderGQ.Sudoku.Enums;
using WasderGQ.Sudoku.Generic;
using WasderGQ.Sudoku.SceneManagement;
using WasderGQ.Sudoku.Scenes.GameScene.Game;
using WasderGQ.Sudoku.Scenes.GameScene.InputModuls;
using WasderGQ.Sudoku.Utility;
using WasderGQ.Utility.DefaultMonoBehaviorObject;

namespace WasderGQ.Sudoku.CoManagers
{
    public class PlayerInputManager : MonoBehaviour
    {
        [SerializeField] private LayerMask _interactable;
        [SerializeField] private Keyboard _keyboard;
        [SerializeField]private Zone _preFabZone;
        [SerializeField]private KeyboardKey _preFabKey;
        private void Update()
        {
            MouseClick();
        }

        private void MouseClick()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Vector3 position = TakeMousePosition();
                RayThrowTakeRaycastHit(out bool isCatch,out RaycastHit raycastHit,position);
                if(isCatch)
                Interact(raycastHit);
            }
        }

        private void RayThrowTakeRaycastHit(out bool iscatch,out RaycastHit raycastHit,Vector3 postion)
        {
            Ray ray = new Ray(postion, Vector3.forward);
            List<RaycastHit> raycastHitList = new List<RaycastHit>(Physics.RaycastAll(ray, float.MaxValue, _interactable));
            if (raycastHitList.Count == 0)
            {
                iscatch = false;
                raycastHit = new RaycastHit();
                return;
            }
            iscatch = true;
            raycastHit = raycastHitList[0];
        }

        private Vector3 TakeMousePosition()
        {
            return Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        private void Interact(RaycastHit raycastHit)
        {
            if (raycastHit.collider.CompareTag("Zone"))
            {
                 
                try
                {
                    Zone zone = raycastHit.collider.GetComponent<Zone>();
                    if (zone.Selected)
                    {
                        zone.DoUnSelected(zone.MyValue);
                        _keyboard.RemoveZoneToList(zone);
                    }
                    else
                    {
                        zone.DoSelected();
                        _keyboard.SaveZoneToList(zone);
                    }
                }
                catch 
                {
                    Debug.LogError("There is no !! MB_Zone !! script on the reached GameObject.");
                }

                
                
            }

            if (raycastHit.collider.CompareTag("KeyboardKey"))
            {
                try
                {
                    KeyboardKey key = raycastHit.collider.GetComponent<KeyboardKey>();
                    key.DoClickAnimation();
                    _keyboard.FillZoneWithValue(key);
                }
                catch 
                {
                    Debug.LogError("There is no !! KeyboardKey !! script on the reached GameObject.");
                }
                
            }
            if (raycastHit.collider.CompareTag("WinBackground"))
            {
                try
                {
                    SceneLoader.Instance.LoadScene(EnumScenes.MainMenuScene);
                }
                catch (Exception e)
                {
                    Debug.LogError("Parent not contain WinScene Component");
                }
                
            }
            
        }
    }
}

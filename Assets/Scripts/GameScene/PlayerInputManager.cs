using System;
using System.Collections.Generic;
using UnityEngine;
using WasderGQ.GameScene.Game;
using WasderGQ.Sudoku.GameScene.InputModuls;

namespace WasderGQ.Sudoku.GameScene
{
    public class PlayerInputManager : MonoBehaviour
    {
        [SerializeField] private LayerMask _interactable;
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
                RaycastHit raycastHit = RayThrowTakeRaycastHit(position);
                Interact(raycastHit);
            }
            
            
        }

        private RaycastHit RayThrowTakeRaycastHit(Vector3 postion)
        {
            Ray ray = new Ray(postion, Vector3.forward);
            List<RaycastHit> raycastHitList = new List<RaycastHit>(Physics.RaycastAll(ray, float.MaxValue, _interactable));
            Debug.Log(raycastHitList[0].collider.tag);
            return raycastHitList[0];
            
        }

        private Vector3 TakeMousePosition()
        {
            Debug.Log(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            return Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        private void Interact(RaycastHit raycastHit)
        {
            if (raycastHit.collider.CompareTag("Zone"))
            {
                Zone zone = new Zone();
                try
                {
                    zone = raycastHit.collider.GetComponent<Zone>();
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

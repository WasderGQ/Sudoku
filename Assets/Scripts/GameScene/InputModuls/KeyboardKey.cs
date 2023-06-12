using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace WasderGQ.Sudoku.GameScene.InputModuls
{
    public class KeyboardKey : MonoBehaviour
    {
        [SerializeField] private int _myValue;
        [SerializeField] private Image _myImage;
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

        public async void DoClickAnimation()
        {
            _myImage.color = Color.gray;
            Task.Delay(1000);
            _myImage.color = Color.white;
        }
    }
}

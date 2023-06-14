using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using WasderGQ.ThirdPartyUtility.DOTween.Modules;

namespace WasderGQ.Sudoku.Scenes.GameScene.InputModuls
{
    public class KeyboardKey : MonoBehaviour
    {
        [SerializeField] private int _myValue;
        [SerializeField] private SpriteRenderer _myImage;
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
            _myImage.DOColor(Color.gray, 0.1f);
            await Task.Delay(10);
            _myImage.DOColor(Color.white, 0.1f);
        }
    }
}

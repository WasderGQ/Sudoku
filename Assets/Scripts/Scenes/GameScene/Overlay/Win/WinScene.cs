using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using WasderGQ.ThirdPartyUtility.DOTween.Modules;
using Task = System.Threading.Tasks.Task;

namespace WasderGQ.Sudoku
{
    public class WinScene : MonoBehaviour
    {
        [SerializeField]private Image _backgorund;
        private bool _canAnimationContinue;

        private void Start()
        {
            StartCoroutine("StartAnimation");
            
        }


        private  IEnumerator StartAnimation()
        {
            while (!_canAnimationContinue)
            {
                _backgorund.DOColor(Color.white, 0.75f);
                yield return new WaitForSeconds(1.0f);
                _backgorund.DOColor(Color.cyan, 0.75f);
                yield return new WaitForSeconds(1.0f);
                _backgorund.DOColor(Color.blue, 0.75f);
                yield return new WaitForSeconds(1.0f);
                _backgorund.DOColor(Color.magenta, 0.75f);
                yield return new WaitForSeconds(1.0f);
                _backgorund.DOColor(Color.red, 0.75f);
                yield return new WaitForSeconds(1.0f);
                _backgorund.DOColor(Color.yellow, 0.75f);
                yield return new WaitForSeconds(1.0f);
                _backgorund.DOColor(Color.green, 0.75f);
                yield return new WaitForSeconds(1.0f);
            }
            
            yield return null ;
        }
        
    }
}

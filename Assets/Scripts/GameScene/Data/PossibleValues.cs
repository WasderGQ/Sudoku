using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

namespace Assets.Scripts.GameScene
{




    public class PossibleValues :  IEnumerable  // denemek için yapıldı kullanma!!!!
    {
       private PossibleValue[] _possibleValueList;
       private int position = -1;


        public PossibleValues()
        {
            _possibleValueList = new PossibleValue[9]
            {
            new PossibleValue(1), new PossibleValue(2), new PossibleValue(3), new PossibleValue(4), new PossibleValue(5), new PossibleValue(6), new PossibleValue(7), new PossibleValue(8), new PossibleValue(9)
            };





        }



        
        public IEnumerator GetEnumerator()
        {
            return (IEnumerator)this;
        }
        //IEnumerator
        public bool MoveNext()
        {
            position++;
            return (position < _possibleValueList.Length);
        }
        //IEnumerable
        public void Reset()
        {
            position = -1;
        }
        //IEnumerable
        public object Current
        {
            get { return _possibleValueList[position]; }
        }


        public class PossibleValue
            {
            public int value;

            public PossibleValue(int x )
            {
                value = x;

            }



            }


    }

}


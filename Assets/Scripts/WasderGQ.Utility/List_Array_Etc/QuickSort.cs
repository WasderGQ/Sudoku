using System;
using System.Collections.Generic;
using System.Linq;

namespace WasderGQ.Sudoku.Utility
{
    public static class QuickSort
    {
        
        public static void QuickSortArray<T1>(this T1[] array) where T1 : IComparableObj
        {
            foreach (var element in array)
            {
                Partion<T1>(element,array);
            }
        }

        private static void Partion<T1>(T1 element,T1[] array) where T1 : IComparableObj
        {
            int count = 0;
            List<T1> tempList = array.ToList();
            tempList.Remove(element);
            for (int i = 0; i < tempList.Count-1; i++)
            {
                if (element.ComparableValue > tempList[i].ComparableValue)
                {
                    count++;
                }
            }
            Swap(count, element, array);
        }
        
        private static void Swap<T1>(int changeIndex,T1 element,T1[] array)
        {
            T1 temp = array[changeIndex];
            array[changeIndex] = element;
            array[array.Length - 1] = temp;
        }
    }
    public interface IComparableObj
    {
        public int ComparableValue { get; }
            
    }
}

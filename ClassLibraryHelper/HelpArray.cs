using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryHelper
{
    public class HelpArray
    {
        public static Array MakeArray(Type type, int length)
        {
            var rnd = new Random();

            var array = Array.CreateInstance(type, length);

            for (int i = 0; i < array.Length; i++)
            {
                if (type == typeof(char)) array.SetValue((char)rnd.Next(0, 50), i);
                else array.SetValue(rnd.Next(0, 50), i);
            }
            return array;
        }
        
        public static Array BubbleSortArray(Array array, IComparer comparer)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length; j++)
                {
                    if (comparer.Compare(array.GetValue(i), array.GetValue(j)) < 0)
                    {
                        Swap(array, i, j);
                    }
                }
            }
            return array;
        }

        public static Array ShakeSortArray(Array array, IComparer comparer)
        {
            int right = array.Length - 1;
            int left = 0;

            while (left <= right)
            {
                for(int i = left; i < right; i++)
                {
                    if (comparer.Compare(array.GetValue(i), array.GetValue(i + 1)) > 0)
                    {
                        array = Swap(array, i, i + 1);
                    }
                }
                right--;

                for(int j = right; j > left; j--)
                {
                    if (comparer.Compare(array.GetValue(j), array.GetValue(j - 1)) < 0)
                    {
                        array = Swap(array, j, j - 1);
                    }

                }
                left++;
            }
            return array;
        }
        public static Array BrushSortArray(Array array, IComparer comparer)
        {
            const double ratio = 1.247;
            int step = array.Length;
            bool swaped = true;

            while (step > 1 || swaped)
            {
                step = (int)(step / ratio);
                if (step < 1) step = 1;
                swaped = false;

                for (int i = 0; i + step < array.Length; i++)
                {
                    if (comparer.Compare(array.GetValue(i), array.GetValue(i + step)) > 0)
                    {
                        array = Swap(array, i, i + step);
                        swaped = true;
                    }
                }

            }

            return array;
        }
        private static Array Swap(Array array, int i, int j)
        {
            var temp = array.GetValue(j);
            array.SetValue(array.GetValue(i), j);
            array.SetValue(temp, i);
            return array;
        }

        public static void WriteArray(Array array)
        {
            Console.WriteLine("Массив:");
            foreach (var element in array)
                Console.WriteLine(element.ToString());
        }
    }

    public class SortToUp : IComparer
    {
        public int Compare(object x, object y)
        {
            var obj1 = (IComparable)x;
            var obj2 = (IComparable)y;
            return obj1.CompareTo(obj2);
        }
    }

    public class SortToDown : IComparer
    {
        public int Compare(object x, object y)
        {
            var obj1 = (IComparable)x;
            var obj2 = (IComparable)y;
            return obj2.CompareTo(obj1);
        }
    }
}

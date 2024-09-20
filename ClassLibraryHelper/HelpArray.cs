using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

        public static Array SortArray(Array array, IComparer comparer)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length; j++)
                {
                    if (comparer.Compare(array.GetValue(i), array.GetValue(j)) < 0)
                    {
                        var temp = array.GetValue(j);
                        array.SetValue(array.GetValue(i), j);
                        array.SetValue(temp, i);
                    }
                }
            }
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

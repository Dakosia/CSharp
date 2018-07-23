using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrlShortener
{
    #region UrlShortener
    //public class UrlShortener
    //{
    //    private const string Alphabet = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ-_";
    //    private static readonly int Base = Alphabet.Length;

    //    public static string Encode(int num)
    //    {
    //        StringBuilder sb = new StringBuilder();
    //        while (num > 0)
    //        {
    //            sb.Insert(0, Alphabet.ElementAt(num % Base));
    //            num = num / Base;
    //        }
    //        return sb.ToString();
    //    }

    //    public static int Decode(string str)
    //    {
    //        var num = 0;
    //        foreach (var item in str)
    //        {
    //            num = num * Base + Alphabet.IndexOf(item);
    //        }
    //        return num;
    //    }
    //}
    #endregion

    public interface IUrlShortener
    {
        string Short(string url);
    }

    public class UrlShortener : IUrlShortener
    {
        private Random _random;
        private int _length;
        private Tuple<int, int> _asciiRange;
        public string Short(string input)
        {
            string output = string.Empty;
            for (int i = 1; i <= _length; i++)
            {
                output += (char)_random.Next(_asciiRange.Item1, _asciiRange.Item2);
            }
            return output;
        }

        public UrlShortener()
        {
            _random = new Random();
            _length = 6;
            _asciiRange = new Tuple<int, int>(65, 91);
        }
    }
}

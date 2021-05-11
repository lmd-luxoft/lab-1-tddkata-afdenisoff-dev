// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using System;
using System.Collections.Generic;
using System.Linq;

namespace TDDKata
{
    internal class StringCalc
    {
        private const char separator = ',';

        internal int Sum(string v)
        {
            if (string.IsNullOrWhiteSpace(v))
            {
                return 0;
            }

            var intArray = GetIntArray(v);

            if (!Validate(intArray))
            {
                return -1;
            }

            var result = 0;

            foreach (var item in intArray)
            {
                result += item;
            }

            return result;
        }


        private int[] GetIntArray(string source)
        {
            var result = new List<int>();

            foreach (var arg in source.Split(separator))
            {
                if (!int.TryParse(arg, out int intValue))
                {
                    return Array.Empty<int>();
                }

                result.Add(intValue);
            }

            return result.ToArray();
        }

        private bool Validate(IEnumerable<int> source)
        {
            if (source.Count() == 0 || source.Count() > 2)
            {
                return false;
            }

            if (source.Any(value => value < 0))
            {
                return false;
            }

            return true;
        }
    }
}
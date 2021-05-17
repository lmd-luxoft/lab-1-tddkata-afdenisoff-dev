// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using System;
using System.Collections.Generic;
using System.Linq;

namespace TDDKata
{
    internal class StringCalc
    {
        private const string separatorBase = ",";
        private const string separatorsArrayPrefix = "//";
        private const string separatorsArraySuffix = @"\n";

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
            
            foreach (var arg in source.Split(GetSeparators(source), StringSplitOptions.RemoveEmptyEntries))
            {
                if (int.TryParse(arg, out int intValue))
                {
                    result.Add(intValue);
                }

            }

            return result.ToArray();
        }

        private bool Validate(IEnumerable<int> source)
        {
            if (source.Count() == 0)
            {
                return false;
            }

            if (source.Any(value => value < 0))
            {
                return false;
            }

            return true;
        }

        private string[] GetSeparators(string source)
        {
            var separators = new List<string>() { separatorBase, separatorsArraySuffix };

            if (source.StartsWith(separatorsArrayPrefix))
            {
                var tmpString = source.TrimStart(separatorsArrayPrefix.ToCharArray());

                separators.Add(tmpString.Substring(0, tmpString.IndexOf(separatorsArraySuffix)));
            }

            return separators.ToArray();
        }
    }
}
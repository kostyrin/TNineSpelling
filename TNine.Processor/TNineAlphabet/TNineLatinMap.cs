using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using TNine.Common;

namespace TNine.Processor.TNineAlphabet
{
	public class TNineLatinMap: TNineAlphabetMap
	{
        private readonly SortedDictionary<string, char> _latinMap;

        public TNineLatinMap()
		{
			_latinMap = new SortedDictionary<string, char>();
			InitAlphabetMap();
		}
		
		public override char[] GetT9CharArray(char symbol)
		{
		    var result = _latinMap.FirstOrDefault(l => l.FunctorMethod(symbol));

            if (result.Equals(default(KeyValuePair<string, char>))) throw new ArgumentNullException($"{TNineResource.BadInputSymbol} {symbol} ");

            int appendTimes = result.Key.IndexOf(symbol);
            if (appendTimes == -1) throw new IndexOutOfRangeException(symbol.ToString());

            var output = new char[appendTimes + 1];
            for (int repeat = 0; repeat <= appendTimes; repeat++)
			{
                output[repeat] = result.Value;
			}
			return output;
		}

	    protected override void InitAlphabetMap()
		{
			 _latinMap.Add("abc", '2');
			 _latinMap.Add("def", '3');
			 _latinMap.Add("ghi", '4');
			 _latinMap.Add("jkl", '5');
			 _latinMap.Add("mno", '6');
			 _latinMap.Add("pqrs", '7');
			 _latinMap.Add("tuv", '8');
			 _latinMap.Add("wxyz", '9');
			 _latinMap.Add(" ", '0');
		}

        public new void Dispose()
        {
            base.Dispose();
        }
    }
}




using System.Collections.Generic;
using System.Linq;

namespace TNine.Processor.TNineAlphabet
{
	public static class TNineLatinSymbolFind
	{
		public static bool FunctorMethod(this KeyValuePair<string, char> item, char searchingSymbol)
		{
			return item.Key.ToCharArray().Any(k => k.Equals(searchingSymbol));
		}
	}
}


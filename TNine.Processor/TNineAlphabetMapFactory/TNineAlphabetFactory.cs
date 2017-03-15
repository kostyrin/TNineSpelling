using TNine.Processor.TNineAlphabet;

namespace TNine.Processor.TNineAlphabetMapFactory
{
	public class TNineAlphabetFactory
	{
		public static TNineAlphabetMap Create(TNineAlhabetMapType alphabetType)
		{
			return new TNineLatinMap();
		}
	}
}




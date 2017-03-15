using System;
using System.Linq;
using System.Text;
using TNine.Processor.TNineAlphabet;
using TNine.Processor.TNineAlphabetMapFactory;

namespace TNine.Processor.TNineStringProcessor
{
	public class TNineStringProcessor : System.IDisposable
	{
        private readonly TNineAlphabetMap _t9Alphabet;

        public TNineStringProcessor(TNineAlhabetMapType alphabetType)
		{
			_t9Alphabet = TNineAlphabetFactory.Create(alphabetType);
		}

		public void Dispose()
		{
			_t9Alphabet.Dispose();
		}

		public string Process(string processingString, bool isLarge)
		{
			if (string.IsNullOrEmpty(processingString))
			{
				return string.Empty;
			}

		    var currentLength = processingString.Length;

            if ((!isLarge && (currentLength < 1 || currentLength > 15)) 
                || (isLarge && (currentLength < 1 || currentLength > 1000)))
                    throw new ArgumentOutOfRangeException(processingString);

            StringBuilder resultString = new StringBuilder();
            char previosChar = new char();

            foreach (char symbol in processingString)
            {
                var numbers = _t9Alphabet.GetT9CharArray(symbol);
                if (previosChar.Equals(numbers.Last()))
                {
                    resultString.Append(' ');
                }
                resultString.Append(numbers);

                previosChar = numbers.Last();
            }
            
			return resultString.ToString();
		}
		
	}
}




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

            if ((!isLarge && processingString.Length < 1 && processingString.Length > 15) 
                || (isLarge && processingString.Length < 1 && processingString.Length > 1000))
                    throw new ArgumentOutOfRangeException(processingString);

            StringBuilder resultString = new StringBuilder();
            char previosChar = new char();

            foreach (char symbol in processingString)
            {
                var numbers = _t9Alphabet.GetT9CharArray(symbol);
                if (numbers.Last() == previosChar)
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




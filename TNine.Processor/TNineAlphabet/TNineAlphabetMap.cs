namespace TNine.Processor.TNineAlphabet
{
	public abstract class TNineAlphabetMap : System.IDisposable
	{
		public virtual void Dispose()
		{
		}

        public virtual char[] GetT9CharArray(char symbol)
	    {
	        throw new System.NotImplementedException();
	    }

	    protected abstract void InitAlphabetMap();
	}
}


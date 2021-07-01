using System;
using System.Collections.Generic;
using System.Text;

namespace Pokemons_Example
{
	class MissingMovementException : Exception
	{
		public MissingMovementException(string errorMessage) : base(errorMessage)
		{
		}

		public Movement GetDefaultMovement() 
		{
			return new DefaultError();
		}
	}
}

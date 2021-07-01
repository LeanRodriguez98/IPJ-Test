using System;
using System.Collections.Generic;
using System.Text;

namespace Pokemons_Example
{
	public abstract class PokemonState
	{
		public abstract Pokemon ApplyEffect(Pokemon affected);
	}

	public sealed class Poisoned : PokemonState 
	{
		int maxTurns = 3;
		int appliedTurns = 0;

		public override Pokemon ApplyEffect(Pokemon affected)
		{
			affected.vida -= (affected.maxVida / 16);
			appliedTurns++;

			if (new Random().Next(appliedTurns, maxTurns) == maxTurns)
			{
				affected.state = null;
			}

			return affected;
		}
	}
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Pokemons_Example
{
	class Game
	{
		public Game()
		{
			Pokemon charmander = PokemonReader.ReadPokemonFromFile("Caterpie.PKM");
		}
	}
}

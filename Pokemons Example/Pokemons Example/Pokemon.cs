using System;
using System.Collections.Generic;
using System.Text;

namespace Pokemons_Example
{
	public class Pokemon
	{
		public string name;
		public int nivel;
		public List<Type> tipos;
		public int vida;
		public int maxVida;
		public int ataque;
		public int ataqueEpecial;
		public int defensa;
		public int defensaEspecial;
		public int velocidad;
		public PokemonState state;


		public List<Movement> moves;

		public Pokemon()
		{
			tipos = new List<Type>();
			moves = new List<Movement>();
		}
	}
}

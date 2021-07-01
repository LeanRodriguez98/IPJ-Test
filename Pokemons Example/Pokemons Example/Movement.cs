using System;
using System.Collections.Generic;
using System.Text;

namespace Pokemons_Example
{
	public abstract class Movement
	{
		public string nombre;
		public int potencia;
		public int maxUses;
		public int presicion;
		public string tipo;
		public abstract Pokemon Use(Pokemon caster, Pokemon objective);
	}


	public sealed class DefaultError : Movement
	{
		public DefaultError()
		{
			nombre = "DefaultError";
			potencia = 0;
			maxUses = 0;
			presicion = 0;
			tipo = "Normal";
		}

		public override Pokemon Use(Pokemon caster, Pokemon objective)
		{
			return objective;
		}
	}


	public sealed class Placaje : Movement
	{
		public Placaje()
		{
			nombre = "Placaje";
			potencia = 30;
			maxUses = 20;
			presicion = 95;
			tipo = "Normal";
		}

		public override Pokemon Use(Pokemon caster, Pokemon objective)
		{
			objective.vida -= (caster.ataque - objective.defensa);
			return objective;
		}
	}

	public sealed class Lanzallamas : Movement
	{
		public Lanzallamas()
		{
			nombre = "Lanzallamas";
			potencia = 80;
			maxUses = 10;
			presicion = 90;
			tipo = "Fuego";
		}

		public override Pokemon Use(Pokemon caster, Pokemon objective)
		{
			objective.vida -= (caster.ataqueEpecial - objective.defensaEspecial);
			return objective;
		}
	}
}

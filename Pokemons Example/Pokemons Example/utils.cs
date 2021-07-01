using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Pokemons_Example
{
	public static class PokemonReader
	{
		public static Pokemon ReadPokemonFromFile(string path)
		{
			Pokemon P = new Pokemon();

			string[] lines = File.ReadAllLines(path);

			P.name = lines[0];
			P.nivel = Convert.ToInt32(lines[1]);

			string[] types = lines[2].Split(" ");
			for (int i = 0; i < types.Length; i++)
			{
				P.tipos.Add(Types.GetInstance().GetType(types[i]));
			}

			P.vida = Convert.ToInt32(lines[3]);
			P.maxVida = Convert.ToInt32(lines[3]);
			P.ataque = Convert.ToInt32(lines[4]);
			P.ataqueEpecial = Convert.ToInt32(lines[5]);
			P.defensa = Convert.ToInt32(lines[6]);
			P.defensaEspecial = Convert.ToInt32(lines[7]);
			P.velocidad = Convert.ToInt32(lines[8]);
			if (lines.Length >= 9)
			{
				P.moves.Add(MovementDatabase.GetMovement(lines[9]));
			}
			if (lines.Length >= 10)
			{
				P.moves.Add(MovementDatabase.GetMovement(lines[10]));
			}
			if (lines.Length >= 11)
			{
				P.moves.Add(MovementDatabase.GetMovement(lines[11]));
			}
			if (lines.Length >= 12)
			{
				P.moves.Add(MovementDatabase.GetMovement(lines[12])));
			}

			return P;
		}
	}

	public static class MovementDatabase
	{
		public static Movement GetMovement(string movementName)
		{
			try
			{
				switch (movementName)
				{
					case "Lanzallamas":
						return new Lanzallamas();
					case "Placaje":
						return new Placaje();
					default:
						throw new MissingMovementException("The movement whit name " + movementName + " dos't exist or is not added to the dartabase");
				}
			}
			catch (MissingMovementException e)
			{
				Console.WriteLine(e.Message);
				return e.GetDefaultMovement();
			}
		}
	}
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Pokemons_Example
{
	public enum Type { Fuego, Agua, Planta, Normal, Error }
	public class Types
	{
		private Dictionary<string, Type> typesDatabase = new Dictionary<string, Type>();

		private static Types instance;
		public static Types GetInstance()
		{
			if (instance == null)
			{
				instance = new Types();
			}
			return instance;
		}
		private Types()
		{
			typesDatabase.Add("Fuego", Type.Fuego);
			typesDatabase.Add("Agua", Type.Agua);
			typesDatabase.Add("Planta", Type.Planta);
			typesDatabase.Add("Normal", Type.Normal);
		}

		public Type GetType(string typeName)
		{
			if (typesDatabase.ContainsKey(typeName))
			{
				return typesDatabase[typeName];
			}
			else
			{
				Console.WriteLine("Error!");
				return Type.Error;
			}
		}

	}
}

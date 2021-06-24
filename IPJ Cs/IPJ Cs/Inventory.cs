using System.Collections.Generic;
using System.IO;

class Inventory
{
	private List<InventorySlot> inventory;
	private int size;

	public Inventory(int size)
	{
		this.size = size;
	}

	public List<InventorySlot> GetInventories()
	{
		return inventory;
	}

	public void AddItem(Item item, int amount)
	{
		bool alreadyContained = false;
		for (int i = 0; i < inventory.Count; i++)
		{
			if (inventory[i].item.name == item.name)
			{
				alreadyContained = true;
			}
		}

		if (alreadyContained)
		{
			for (int i = 0; i < inventory.Count; i++)
			{
				if (inventory[i].item.name == item.name)
				{
					inventory[i].amount += amount;
				}
			}
		}
		else
		{
			if (inventory.Count < size)
			{
				inventory.Add(new InventorySlot(item, amount));
			}
			else
			{
				//muchos items, tira alguno
			}
		}
	}
}

public class InventorySlot
{
	public Item item;
	public int amount;

	public InventorySlot(Item item, int amount)
	{
		this.item = item;
		this.amount = amount;
	}
}

public class Item
{
	public string name;
	public int price;
	protected string description;

	public Item(string name, int price, string description)
	{
		this.name = name;
		this.price = price;
		this.description = description;
	}
}

abstract class Consumables : Item
{
	int _quantity;
	public Consumables(string name, int price, string description, int quantity) : base(name, price, description)
	{
		_quantity = quantity;
	}
}

class Potion : Consumables
{
	public Potion(string name, int price, string description, int quantity) : base(name, price, description, quantity)
	{
	}
}
abstract class Food : Consumables
{
	public Food(string name, int price, string description, int quantity) : base(name, price, description, quantity)
	{
	}
}
sealed class Arrow : Consumables
{
	public Arrow(string name, int price, string description, int quantity) : base(name, price, description, quantity)
	{
	}
}
abstract class Equipment : Item
{
	public Equipment(string name, int price, string description) : base(name, price, description)
	{

	}
}
abstract class Armadura : Equipment
{
	public Armadura(string name, int price, string description) : base(name, price, description)
	{

	}
}
sealed class armaduraCuero : Armadura
{
	public armaduraCuero(string name, int price, string description) : base(name, price, description)
	{
	}
}

//////////////////////////////////////
///





public abstract class Pokemon : ISaveLoad
{
	public int pokedexID;
	public string name;
	protected int lvl;
	public Pokemon(int pokedexID, string name)
	{
		this.pokedexID = pokedexID;
		this.name = name;
		lvl = 1;
	}


	public void Attack() { }

	public BinaryReader Load(BinaryReader br)
	{
		return br;
	}

	public BinaryWriter Save(BinaryWriter bw)
	{
		return bw;
	}
}

public class Charmander : Pokemon
{

	public Charmander(int PokedexID, string name) : base(PokedexID, name)
	{
	}


}

public sealed class Boulbasour : Pokemon
{

	public Boulbasour(int PokedexID, string name) : base(PokedexID, name)
	{
	
	}
}


public class PokemonTrainer 
{
	List<Pokemon> team = new List<Pokemon>();

	public PokemonTrainer() 
	{
		team.Add(new Charmander(1, "Charmander"));
		team.Add(new Boulbasour(2, "Boulbasour"));
	}
}


///////////////////////////////
///







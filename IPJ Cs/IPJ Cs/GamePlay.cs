using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

class GamePlay
{
	private Player player;
	private Inn inn;
	private Tower tower;

	public GamePlay()
	{
		bool load = false;
		if (load)
		{
			LoadGame();
		}
		else
		{
			StartNewGame();
		}
		//Save();
	}

	public void LoadGame()
	{
		Load();
		inn = new Inn();
	}

	public void StartNewGame()
	{
		player = new Player("Pepe", 100, 20, Location.Inn);
		inn = new Inn();
		tower = new Tower(10);
	}

	public bool Play()
	{
		switch (player.GetLocation())
		{
			case Location.Inn:
				player = inn.Stay(player);
				break;
			case Location.Tower:
				player = tower.StayInside(player);
				break;
			default:
				Console.WriteLine("ERROR!");
				break;
		}

		return true;
	}

	public void Save()
	{
		Stream save = File.Open("MySave.sav", FileMode.OpenOrCreate);
		BinaryWriter bw = new BinaryWriter(save);
		bw = player.Save(bw);
		bw = tower.Save(bw);
		bw.Close();
		save.Close();
	}

	public void Load()
	{

		try
		{
			Stream file = File.Open("MySave.sav", FileMode.Open);

			BinaryReader br = new BinaryReader(file);
			player = new Player();
			br = player.Load(br);
			tower = new Tower();
			br = tower.Load(br);
			br.Close();
			file.Close();
		}
		catch (System.IO.FileNotFoundException)
		{
			StartNewGame();
		}


	}

}

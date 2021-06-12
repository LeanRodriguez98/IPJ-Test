using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

class Tower
{
	enum Options { Enter, Fight, Leave, GoToNextFloor, Error };
	enum OnEnterOption { Leave, Fight, Error };
	enum OnFinishFightOption { Leave, GoToNextFloor, Error };


	private List<Floor> floors;
	private int lastVisitedFloor;
	private Options currentOption;
	public Tower(int floorsAmount)
	{
		floors = new List<Floor>();
		for (int i = 0; i < floorsAmount; i++)
		{
			floors.Add(new Floor(4));
		}
		lastVisitedFloor = 0;
		currentOption = Options.Enter;
	}

	public Tower() 
	{
	}

	public BinaryWriter Save(BinaryWriter bw) 
	{
		bw.Write(floors.Count);
		for (int i = 0; i < floors.Count; i++)
		{
			bw = floors[i].Save(bw);
		}
		bw.Write(lastVisitedFloor);
		bw.Write((int)currentOption);
		return bw;
	}

	public BinaryReader Load(BinaryReader br) 
	{
		int floorsCount = br.ReadInt32();
		floors = new List<Floor>();
		for (int i = 0; i < floorsCount; i++)
		{
			Floor floor = new Floor();
			br = floor.Load(br);
			floors.Add(floor);
		}
		lastVisitedFloor = br.ReadInt32();
		currentOption = (Options)br.ReadInt32();
		return br;
	}

	public Player StayInside(Player player)
	{
		switch (currentOption)
		{
			case Options.Enter:
				Enter();
				break;
			case Options.Fight:
				player = Fight(player);
				break;
			case Options.Leave:
				player = Leave(player);
				break;
			case Options.GoToNextFloor:
				GoToNextFloor();
				break;
			default:
				break;
		}
		return player;
	}

	public void Enter()
	{
		Console.WriteLine("Welcome to the tower");
		OnEnterOption onEnterOption;

		Console.WriteLine("Leave = 0   -   Fight = 1");

		int input = Convert.ToInt32(Console.ReadLine());

		if (input >= 0 && input < (int)OnEnterOption.Error)
		{
			onEnterOption = (OnEnterOption)input;
		}
		else
		{
			onEnterOption = OnEnterOption.Error;
		}

		switch (onEnterOption)
		{
			case OnEnterOption.Leave:
				currentOption = Options.Leave;
				break;
			case OnEnterOption.Fight:
				currentOption = Options.Fight;
				break;
			default:
				break;
		}

	}

	public Player Fight(Player player)
	{
		player = floors[lastVisitedFloor].Fight(player);

		if (floors[lastVisitedFloor].enemies.Count == 0)
		{
			lastVisitedFloor++;
			OnFinishFightOption onFinishFightOption;

			Console.WriteLine("Leave = 0   -   Go to Next Floor = 1");

			int input = Convert.ToInt32(Console.ReadLine());

			if (input >= 0 && input < (int)OnFinishFightOption.Error)
			{
				onFinishFightOption = (OnFinishFightOption)input;
			}
			else
			{
				onFinishFightOption = OnFinishFightOption.Error;
			}

			switch (onFinishFightOption)
			{
				case OnFinishFightOption.Leave:
					currentOption = Options.Leave;
					break;
				case OnFinishFightOption.GoToNextFloor:
					currentOption = Options.GoToNextFloor;
					break;
				default:
					break;
			}

		}

		return player;
	}

	public Player Leave(Player player)
	{
		player.GoToInn();
		return player;
	}

	public void GoToNextFloor()
	{

	}
}

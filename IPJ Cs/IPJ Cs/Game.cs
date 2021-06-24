using System;
using System.Collections.Generic;
using System.Text;

class Game
{
	private static Game instance;

	public static Game GetInstance() 
	{
		if (instance == null)
		{
			instance = new Game();
		}
		return instance;
	}

	enum State {Gameplay, Pause };

	private GamePlay gameplay;
	private PauseMenu pauseMenu;
	private static State state;

	private Game() 
	{
		gameplay = new GamePlay();
		pauseMenu = new PauseMenu();
		state = State.Gameplay;
	}

	public bool Update()
	{
		switch (state)
		{
			case State.Gameplay:
				gameplay.Play();
				break;
			case State.Pause:
				pauseMenu.Pause();
				break;
			default:
				break;
		}
		return true;
	}

	public void GoToPause()
	{
		state = State.Pause;
	}

	public void GoToGameplay()
	{
		state = State.Gameplay;
	}

}

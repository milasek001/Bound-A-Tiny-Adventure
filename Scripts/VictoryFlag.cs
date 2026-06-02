using Godot;
using System;

public partial class VictoryFlag : Area2D
{
	[Export] public CanvasLayer victoryMenu;
	[Export] public string nextLevel;
	[Export] public int currentLevelNumber = 1;
	
	public void OnBodyEntered(Node2D body)
	{
		if (body is CharacterBody2D player)
		{
			HUD hud = GetTree().CurrentScene.GetNodeOrNull<HUD>("HUD");
			if (hud != null)
			{
				int gatheredCoins = hud.GetCoinCount();
				string finalTime = hud.GetFormattedTime();
				
				GetNode<GameData>("/root/GameData").UnlockNextLevel(currentLevelNumber);
				
			if (victoryMenu is VictoryMenu script) 
		{
			script.DisplayResults(gatheredCoins, finalTime);
			script.targetLevel = nextLevel;
		}
			if (victoryMenu != null)
			{
				victoryMenu.Visible = true;
				GetTree().Paused = true; 
			}		
			}
		}
	}
}

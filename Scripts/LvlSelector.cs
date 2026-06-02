using Godot;
using System;

public partial class LvlSelector : Control
{
	
	[Export] public Button Level1Btn;
	[Export] public Button Level2Btn;
	[Export] public Button Level3Btn;
	[Export] public Button Level4Btn;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		var music = GD.Load<AudioStream>("res://Assets/Music/Custom Music/Pixel Menu Drift.mp3"); // Cesta k tvé hudbě
		GetNode<MusicManager>("/root/MusicManager").PlayMusic(music);
		
		var gameData = GetNode<GameData>("/root/GameData");

		Level1Btn.Disabled = !gameData.UnlockedLevels[1];
		Level2Btn.Disabled = !gameData.UnlockedLevels[2];
		Level3Btn.Disabled = !gameData.UnlockedLevels[3];
		Level4Btn.Disabled = !gameData.UnlockedLevels[4];
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	private void OnButtonBackPressed()
	{
		GetTree().ChangeSceneToFile("res://Scenes/main_menu.tscn");
	}
	private void OnButtonLvl1Pressed()
	{
		GetTree().ChangeSceneToFile("res://Scenes/level_1.tscn");
	}
	private void OnButtonLvl2Pressed()
	{
		GetTree().ChangeSceneToFile("res://Scenes/level_2.tscn");
	}
	private void OnButtonLvl3Pressed()
	{
		GetTree().ChangeSceneToFile("res://Scenes/level_3.tscn");
	}
	private void OnButtonLvl4Pressed()
	{
		GetTree().ChangeSceneToFile("res://Scenes/level_4.tscn");
	}
}

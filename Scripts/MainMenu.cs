using Godot;
using System;

public partial class MainMenu : Control
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		var music = GD.Load<AudioStream>("res://Assets/Music/Custom Music/Pixel Menu Drift.mp3"); // Cesta k tvé hudbě
		GetNode<MusicManager>("/root/MusicManager").PlayMusic(music);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	private void OnButtonStartPressed()
	{
		GetTree().ChangeSceneToFile("res://Scenes/lvl_selector.tscn");
	}
	private void OnButtonExitPressed()
	{
		GetTree().Quit();
	}
}

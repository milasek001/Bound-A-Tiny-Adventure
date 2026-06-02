using Godot;
using System;

public partial class PauseMenu : Control
{
	public override void _Ready()
	{
		Visible = false;
	}
	public void testEsc() 
{
	if (Input.IsActionJustPressed("esc"))
	{
		if (!GetTree().Paused) 
		{
			Visible = true;
			GetTree().Paused = true;
		}
		else 
		{
			Visible = false;
			GetTree().Paused = false;
		}
	}
}
	public override void _Process(double delta)
	{
		testEsc();
	}
	public void Resume()
	{
		GetTree().Paused = false;
		Visible = false;
	}
	public void Paused()
	{
		Visible = true;
		GetTree().Paused = true;
	}
	
	private void OnRestartPressed()
	{
		GetTree().Paused = false;
		GetTree().ReloadCurrentScene();
	}
	private void OnBackPressed()
	{
		GetTree().Paused = false;
		GetTree().ChangeSceneToFile("res://Scenes/lvl_selector.tscn");
	}
	public void OnResumePressed()
	{
		Resume();
		
	}
}

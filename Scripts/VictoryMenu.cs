using Godot;
using System;

public partial class VictoryMenu : CanvasLayer
{
	
	public string targetLevel;
	
	[Export] public Label coinResultLabel;
	[Export] public Label timeResultLabel;
	
	public override void _Ready()
	{
		Visible = false;
	}
	
	public void OnButtonNextPressed()
	{
		GetTree().Paused = false;
		GetTree().ChangeSceneToFile(targetLevel);
	}
	private void OnButtonRestartPressed()
	{
		GetTree().Paused = false;
		GetTree().ReloadCurrentScene();
	}
	private void OnButtonBackPressed()
	{
		GetTree().Paused = false;
		GetTree().ChangeSceneToFile("res://Scenes/lvl_selector.tscn");
	}
	public void DisplayResults(int coins, string time)
	{
		coinResultLabel.Text = "Coins: " + coins.ToString();
		timeResultLabel.Text = "Time: " + time;
		Visible = true;
	}
	
}

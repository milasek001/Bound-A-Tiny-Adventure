using Godot;
using System;

public partial class HUD : CanvasLayer
{
	private int _coins = 0;
	private Label _label;
	private double _levelTime = 0;

	public override void _Process(double delta)
	{
		if (!GetTree().Paused)
		{
			_levelTime += delta;
		}
	}
	private void UpdateText()
	{
		if (_label != null)
		{
			_label.Text = _coins.ToString();
		}
	}
	public override void _Ready()
	{
		_label = GetNode<Label>("Control/Panel/HBoxContainer/CoinLabel");
		UpdateText();
	}

	public void CollectCoin()
	{
		_coins++;
		UpdateText();
	}
	public string GetFormattedTime()
	{
		int minutes = (int)(_levelTime / 60);
		int seconds = (int)(_levelTime % 60);
		return string.Format("{0:00}:{1:00}", minutes, seconds);
	}
	public int GetCoinCount() => _coins;
}

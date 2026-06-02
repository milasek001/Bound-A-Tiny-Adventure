using Godot;
using System;

public partial class Killzone : Area2D
{
	private Timer _timer;

	public override void _Ready()
	{
		_timer = GetNode<Timer>("Timer");
	}
	
	private void OnBodyEntered(Node2D body)
	{
		Engine.TimeScale = 0.5f;
	GD.Print("You died!");
	body.GetNode<CollisionShape2D>("CollisionShape2D").QueueFree();
	_timer.Start();
	}
	private void OnTimerTimeout()
{
	Engine.TimeScale = 1.0f;
	GetTree().ReloadCurrentScene();
}
}

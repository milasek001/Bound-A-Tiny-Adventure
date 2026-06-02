using Godot;
using System;

public partial class Coin : Area2D
{
	private AnimationPlayer _animationPlayer => GetNode<AnimationPlayer>("AnimationPlayer");
	
	private void OnBodyEntered(Node2D body)
{
	HUD hud = GetTree().CurrentScene.GetNodeOrNull<HUD>("HUD");
	if (hud != null)
			{
				hud.CollectCoin();
			}
	_animationPlayer.Play("Pickup");
}
}
 

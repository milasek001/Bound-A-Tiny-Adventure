using Godot;
using System;

public partial class JumpPads : Area2D
{

	[Export] public float JumpForce = -700.0f;

	public void OnBodyEntered(Node2D body)
	{
		
		if (body is CharacterBody2D player)
		{
			
			
		
			Vector2 velocity = player.Velocity;
			velocity.Y = JumpForce;
			player.Velocity = velocity;

			
			if (HasNode("AnimatedSprite2D"))
			{
				GetNode<AnimatedSprite2D>("AnimatedSprite2D").Play("Launch");
				GetNode<AudioStreamPlayer2D>("Sound").Play();
			}
			
		}
	}
}

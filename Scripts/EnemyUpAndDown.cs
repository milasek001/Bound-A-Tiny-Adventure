using Godot;
using System;

public partial class EnemyUpAndDown : Node2D
{
	private RayCast2D _rayCastUp;
	private RayCast2D _rayCastDown;
	private AnimatedSprite2D _animatedSprite2d => GetNode<AnimatedSprite2D>("AnimatedSprite2D");

	[Export]private float ChargeSpeed = 40.0f;
	[Export]private float AttackSpeed = 150.0f;
	private float Speed = 40.0f;
	private int _direction = -1;

	public override void _Ready()
	{
		
		_rayCastUp = GetNode<RayCast2D>("RayCastUp");
		_rayCastDown = GetNode<RayCast2D>("RayCastDown");
	}

	public override void _Process(double delta)
	{
		
		if (_rayCastUp.IsColliding())
		{
			_direction = 1;
			Speed = AttackSpeed;
			
			_animatedSprite2d.Play("Angry");
			
		GetNode<AnimatedSprite2D>("AnimatedSprite2D").FlipH = false;
		}
		
		
		if (_rayCastDown.IsColliding())
		{
			_direction = -1;
			Speed = ChargeSpeed;
			_animatedSprite2d.Play("Calm");
			
		GetNode<AnimatedSprite2D>("AnimatedSprite2D").FlipH = true;
		}

		
		Vector2 pos = Position;
		pos.Y += _direction * Speed * (float)delta;
		Position = pos;
	}
}

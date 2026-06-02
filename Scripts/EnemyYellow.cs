using Godot;
using System;

public partial class EnemyYellow : Node2D
	{
	private RayCast2D _rayCastRight;
	private RayCast2D _rayCastLeft;

	private const float Speed = 60.0f;
	private int _direction = 1;

	public override void _Ready()
	{
		
		_rayCastRight = GetNode<RayCast2D>("RayCastRight");
		_rayCastLeft = GetNode<RayCast2D>("RayCastLeft");
	}

	public override void _Process(double delta)
	{
		
		if (_rayCastRight.IsColliding())
		{
			_direction = -1;
			
		GetNode<AnimatedSprite2D>("AnimatedSprite2D").FlipH = false;
		}
		
		
		if (_rayCastLeft.IsColliding())
		{
			_direction = 1;
			
		GetNode<AnimatedSprite2D>("AnimatedSprite2D").FlipH = true;
		}

		
		Vector2 pos = Position;
		pos.X += _direction * Speed * (float)delta;
		Position = pos;
	}
}

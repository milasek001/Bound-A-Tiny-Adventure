using Godot;
using System;

public partial class Player : CharacterBody2D
{
	public const float Speed = 100.0f;
	public const float JumpVelocity = -300.0f;
	
	[Export] public Timer FootstepTimer;
	
	private AnimatedSprite2D _animatedSprite2d => GetNode<AnimatedSprite2D>("AnimatedSprite2D");

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		// Add the gravity.
		if (!IsOnFloor())
		{
			velocity += GetGravity() * (float)delta;
		}

		// Handle Jump.
		if (Input.IsActionJustPressed("jump") && IsOnFloor())
		{
			velocity.Y = JumpVelocity;
			GetNode<AudioStreamPlayer2D>("JumpSound").Play();
		}

		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.
		Vector2 direction = Input.GetVector("move_left", "move_right", "ui_up", "ui_down");
		
		if (direction.X > 0) 
		{
			_animatedSprite2d.FlipH = false;
		} else if(direction.X < 0) 
		{
			_animatedSprite2d.FlipH = true;
		}
		if (IsOnFloor())
		{
			if (direction.X == 0) 
		{
			_animatedSprite2d.Play("Idle");
		} else 
			_animatedSprite2d.Play("Run");
			
		}
		else 
		{
			_animatedSprite2d.Play("Jump");
		}
		
		
		if (direction != Vector2.Zero)
		{
			velocity.X = direction.X * Speed;
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
		}

		Velocity = velocity;
		MoveAndSlide();
		
		bool isMovingHorizontally = Math.Abs(Velocity.X) > 10.0f;

		if (IsOnFloor() && isMovingHorizontally)
		{
			if (FootstepTimer != null && FootstepTimer.IsStopped())
			{
				GetNode<AudioStreamPlayer2D>("RunSound").Play();
				FootstepTimer.Start();
			}
		}
		else
		{
			if (FootstepTimer != null)
			{
				FootstepTimer.Stop();
			}
		}
	}
	
}

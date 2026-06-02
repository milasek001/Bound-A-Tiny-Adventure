using Godot;
using System;

public partial class Biomes : Area2D
{
	[Export] public TileMap MyTileMap;
	[Export] public int SpringLayerIndex = 0; 
	[Export] public int DesertLayerIndex = 1; 
	[Export] public float TransitionTime = 2.5f; 
	
	private void StartDesertTransition()
	{
		if (MyTileMap == null) 
		{
			return;
		}

		Tween tween = GetTree().CreateTween();
		tween.SetParallel(true);

		tween.TweenMethod(Callable.From<float>(a => {
			Color c = MyTileMap.GetLayerModulate(SpringLayerIndex);
			c.A = a;
			MyTileMap.SetLayerModulate(SpringLayerIndex, c);
		}), 1.0f, 0.0f, TransitionTime);

		tween.TweenMethod(Callable.From<float>(a => {
			Color c = MyTileMap.GetLayerModulate(DesertLayerIndex);
			c.A = a;
			MyTileMap.SetLayerModulate(DesertLayerIndex, c);
		}), 0.0f, 1.0f, TransitionTime);
	}
	public void OnBodyEntered(Node2D body)
	{
		if (body is CharacterBody2D)
		{
			StartDesertTransition();
		}
	}
}

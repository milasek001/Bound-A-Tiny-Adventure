using Godot;
using System;

public partial class MusicController : Node2D
{
   
	[Export] public AudioStream MyLevelMusic;

	public override void _Ready()
	{
		if (MyLevelMusic != null)
		{
			var musicManager = GetNode<MusicManager>("/root/MusicManager");
			musicManager.PlayMusic(MyLevelMusic);
		}
	}
}

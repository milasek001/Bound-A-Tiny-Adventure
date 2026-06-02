using Godot;
using System;

public partial class MusicManager : AudioStreamPlayer
{
	public void PlayMusic(AudioStream musicTrack)
	{
		if (Stream == musicTrack && Playing) 
			return;

		Stream = musicTrack;
		Play();
	}
}

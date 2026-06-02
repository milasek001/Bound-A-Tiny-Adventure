using Godot;
using System;
using System.Collections.Generic;

public partial class GameData : Node
{
	private const string SaveFilePath = "user://savegame.json";
	
	public Dictionary<int, bool> UnlockedLevels = new Dictionary<int, bool>()
	{
		{ 1, true },
		{ 2, false },
		{ 3, false },
		{ 4, false }
	};
	
	public void SaveGame()
{
	using var file = FileAccess.Open(SaveFilePath, FileAccess.ModeFlags.Write);
	
	if (file != null)
	{
		var godotDictionary = new Godot.Collections.Dictionary();
		foreach (var kvp in UnlockedLevels)
		{
			godotDictionary[kvp.Key] = kvp.Value;
		}

		string jsonString = Json.Stringify(godotDictionary);
		
		file.StoreString(jsonString);
	}
}
public void LoadGame()
{
	if (!FileAccess.FileExists(SaveFilePath))
	{
		return;
	}

	using var file = FileAccess.Open(SaveFilePath, FileAccess.ModeFlags.Read);
	
	if (file != null)
	{
		string jsonString = file.GetAsText();
		
		var json = new Json();
		var error = json.Parse(jsonString);
		
		if (error == Error.Ok)
		{
			var data = (Godot.Collections.Dictionary)json.Data;
			
			foreach (string key in data.Keys)
			{
				if (int.TryParse(key, out int levelNum))
				{
					UnlockedLevels[levelNum] = (bool)data[key];
				}
			}
		}
	}
}
	
	public override void _Ready()
	{
		LoadGame();
	}

	public void UnlockNextLevel(int currentLevel)
	{
		int nextLevel = currentLevel + 1;
		
		if (UnlockedLevels.ContainsKey(nextLevel))
		{
			UnlockedLevels[nextLevel] = true;
			
			SaveGame();
		}
	}
	
	
}

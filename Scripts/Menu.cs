using Godot;
using System;

public partial class Menu : Control
{
	[Export]
	PackedScene game;

	[Export]
	Button startBtn;

	[Export]
	Button exitBtn;

    public override void _Ready()
    {
        startBtn.Pressed += Start;
		exitBtn.Pressed += Exit;
    }

	void Exit() {
		GetTree().Quit();
	}

	void Start() {
		GetTree().ChangeSceneToPacked(game);
	}


}

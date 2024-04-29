using Godot;
using System;

public partial class Game : Node
{
    public override void _PhysicsProcess(double delta)
    {
		if (Input.IsActionJustPressed("exit")) {
			GetTree().ChangeSceneToFile("res://Scenes/Menu.tscn");
			Input.MouseMode = Input.MouseModeEnum.Visible;
		}

		if (Input.IsKeyPressed(Key.I)) {
			GD.Print(GetParent().GetTreeStringPretty());
		}
    }
}

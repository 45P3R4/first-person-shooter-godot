using Godot;
using System;

public partial class Idle : State
{
	public override void HandleInput(InputEvent @event) {
		if (Input.GetVector("left", "right", "up", "down") != Vector2.Zero)
			fsm.TransitionTo("Walk");
	}
}
